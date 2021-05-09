using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Web.Attributes;
using Secure.SecurityDoors.Web.Constants;
using Secure.SecurityDoors.Web.Extensions;
using Secure.SecurityDoors.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public AccountController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IEmailService emailService)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            var loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user is null)
                {
                    ModelState.AddModelError(string.Empty, "User not found");
                    return View(model);
                }

                var result = await _userManager.IsEmailConfirmedAsync(user);
                if (!result)
                {
                    ModelState.AddModelError("", "Email not confirmed!");
                    return View(model);
                }

                var signInResult = await _signInManager
                    .PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                if (signInResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                //ModelState.AddModelError(string.Empty, CommonResource.AccountLoginError);
            }

            return View(model);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);

            var profileViewModel = new ProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                SecondName = user.SecondName,
                Passport = user.Passport,
                IdentificationNumber = user.IdentificationNumber,
            };

            return View(profileViewModel);
        }

        [AuthorizeRoles(RoleConstant.Admin)]
        [HttpGet]
        public IActionResult Invitation()
        {
            return View();
        }

        [AuthorizeRoles(RoleConstant.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Invitation(InvitationViewModel model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    SecondName = model.SecondName,
                    Gender = model.Gender,
                    Passport = model.Passport,
                    IdentificationNumber = model.IdentificationNumber,
                    Comment = model.Comment,
                };

                var generatedPassword = await GenerateRandomPassword();
                var result = await _userManager.CreateAsync(user, generatedPassword);
                if (result.Succeeded)
                {
                    var role = model.Level.ConvertToRole();

                    await _userManager.AddToRoleAsync(user, role);

                    _emailService.Send(
                        model.Email,
                        "Welcome to SecurityDoors App!",
                        $"Link: {await GenerateConfirmationLinkAsync(user)}\n" +
                        $"Password: {generatedPassword}\n" +
                        $"Role: {role}");

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                ViewBag.Message = "Email confirmed successfully!";
                return View();
            }

            ViewBag.Message = "Error while confirming your email!";
            return View();
        }

        private static Task<string> GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts is null)
            {
                opts = new PasswordOptions()
                {
                    RequiredLength = 8,
                    RequiredUniqueChars = 4,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = true,
                    RequireUppercase = true
                };
            }

            var randomChars = new[]
            {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",
                "abcdefghijkmnopqrstuvwxyz",
                "0123456789",
                "!@$?_-"
            };

            var rand = new Random(Environment.TickCount);
            var chars = new List<char>();

            if (opts.RequireUppercase)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);
            }

            if (opts.RequireLowercase)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);
            }

            if (opts.RequireDigit)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);
            }

            if (opts.RequireNonAlphanumeric)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);
            }

            for (var i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                var rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return Task.FromResult(new string(chars.ToArray()));
        }

        private async Task<string> GenerateConfirmationLinkAsync(User user)
        {
            return Url.Action(
                "ConfirmEmail",
                "Account",
                new
                {
                    userid = user.Id,
                    token = await _userManager.GenerateEmailConfirmationTokenAsync(user)
                },
                protocol: HttpContext.Request.Scheme);
        }
    }
}
