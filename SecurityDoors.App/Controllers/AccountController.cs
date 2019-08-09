using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Logger.Constants;
using SecurityDoors.Core.Logger.Events;
using SecurityDoors.Core.Mailing.Implementations;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityDoors.App.Controllers
{
    /// <summary>
    /// Контроллер для работы с аккаунтом пользователя (Admin, Moderator, User, Visitor).
    /// </summary>
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        private readonly ServicesManager _serviceManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="singInManager">менеджер входа в систему.</param>
        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, ILogger<CardController> logger, DataManager dataManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _serviceManager = new ServicesManager(dataManager);
        }

        /// <summary>
        /// Редактирование списка активных пользователей.
        /// </summary>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditUsersList()
        {
            var models = await _userManager.Users.ToListAsync();

            if (models == null || models.Count == 0)
            {
                _logger.LogWarning(UserUnsuccessfulEvents.ListUsersItemsNotFound, UserLoggerConstants.USERS_LIST_IS_EMPTY);
            }
            else
            {
                _logger.LogInformation(UserSuccessfulEvents.ListUsersItems, UserLoggerConstants.USERS_LIST_IS_NOT_EMPTY + models.Count + AppConstants.DOT);
            }

            return View(models);
        }

        /// <summary>
        /// Удаление выбранного активного пользователя.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление главной страницы.</returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                await _userManager.DeleteAsync(user);

                _logger.LogInformation(UserSuccessfulEvents.DeleteUserItem, UserLoggerConstants.USER_IS_DELETED);
            }

            return RedirectToAction(nameof(EditUsersList));
        }

        /// <summary>
        /// Настройка пользовательских ролей.
        /// </summary>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SettingUsersRoles()
        {
            var models = await _userManager.Users.ToListAsync();

            _logger.LogInformation(UserSuccessfulEvents.ListUsersItems, UserLoggerConstants.USERS_LIST_IS_NOT_EMPTY + models.Count + AppConstants.DOT);

            return View(models);
        }

        /// <summary>
        /// Изменить роли у пользователя.
        /// </summary>
        /// <param name="userId">Id пользователя.</param>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditUsersRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();

                var model = new RoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };

                _logger.LogInformation(UserSuccessfulEvents.EditUserItem, UserLoggerConstants.USER_IS_VALID + CommonLoggerConstants.MODEL_SUCCESSFULLY_UPDATED);

                return View(model);
            }

            _logger.LogWarning(UserUnsuccessfulEvents.EditUserNotFound, UserLoggerConstants.USER_IS_NOT_VALID);

            return NotFound();
        }

        /// <summary>
        /// Изменить роли у пользователя (POST).
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="roles">все роли в приложении.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditUsersRoles(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = await _roleManager.Roles.ToListAsync();
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                _logger.LogInformation(UserSuccessfulEvents.EditUserItem, UserLoggerConstants.USER_IS_VALID + CommonLoggerConstants.MODEL_SUCCESSFULLY_UPDATED);

                return RedirectToAction(nameof(SettingUsersRoles));
            }

            _logger.LogWarning(UserUnsuccessfulEvents.EditUserNotFound, UserLoggerConstants.USER_IS_NOT_VALID);

            return NotFound();
        }

		/// <summary>
		/// Регистрация.
		/// </summary>
		/// <returns>Представление.</returns>
		[HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

		/// <summary>
		/// Регистрация.
		/// </summary>
		/// <param name="model"></param>
		/// <returns>Представление.</returns>
		[HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Nickname = model.Nickname
                };

                var isUniqueNickname = await _serviceManager.Users.CanUserCreateAccountAsync(model.Nickname);

                if (isUniqueNickname)
                {
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);

                        _logger.LogInformation(UserSuccessfulEvents.RegisterUserItem, UserLoggerConstants.USER_IS_REGISTER + " " + UserLoggerConstants.USER_IS_VALID + $"{model.Email}.");

						
						var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
						var callbackUrl = Url.Action(
							"ConfirmEmail",
							"Account",
							new { userId = user.Id, code },
							protocol: HttpContext.Request.Scheme);
						var emailService = new EmailService();
						await emailService.SendEmailAsync(user.Email, "Подтверждение регистрации", $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");

                        var message = new MessageViewModel() { Message = "Регистрация успешна! На вашу почту было отправлено письмо. Для подтверждения регистрации перейдите по ссылке в письме." };

                        return View("SuccessRegistration", message);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"User nickname '{model.Nickname}' is already taken.");
                }
            }

            _logger.LogWarning(UserUnsuccessfulEvents.RegisterUserItemNotFound, UserLoggerConstants.USER_IS_NOT_VALID);

            return View(model);
        }

		/// <summary>
		/// Подтверждение e-mail при переходе по ссылке в письме
		/// </summary>
		/// <param name="userId">ID пользователя</param>
		/// <param name="code">Код</param>
		/// <returns></returns>
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> ConfirmEmail(string userId, string code)
		{
			if (userId == null || code == null)
			{
				return View("Error");
			}

			var user = await _userManager.FindByIdAsync(userId);

			if (user == null)
			{
				return View("Error");
			}

			var result = await _userManager.ConfirmEmailAsync(user, code);

			if (result.Succeeded)
			{
				var message = new MessageViewModel() { Message = "Регистрация успешна! На вашу почту было отправлено письмо. Для подтверждения регистрации перейдите по ссылке в письме." };

				return View("SuccessRegistration", message);
			}
			else
			{
				return View("Error");
			}
		}

		/// <summary>
		/// Вход в систему.
		/// </summary>
		/// <param name="returnUrl">возврат по определенному адресу.</param>
		/// <returns></returns>
		[HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        /// <summary>
        /// Вход в систему.
        /// </summary>
        /// <param name="model">модель пользовательских данных.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager
                    .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    // Проверка на принадлежность URL приложению.
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        _logger.LogInformation(UserSuccessfulEvents.LoginUserItem, UserLoggerConstants.USER_IS_LOGIN + " " + UserLoggerConstants.USER_IS_VALID + $"{model.Email}.");

                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        _logger.LogInformation(UserSuccessfulEvents.LoginUserItem, UserLoggerConstants.USER_IS_LOGIN + " " + UserLoggerConstants.USER_IS_VALID + $"{model.Email}.");

                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");

                    _logger.LogWarning(UserUnsuccessfulEvents.LoginUserItemNotFound, UserLoggerConstants.USER_IS_NOT_VALID);
                }
            }

            return View(model);
        }

        /// <summary>
        /// Выход из системы.
        /// </summary>
        /// <returns>Перенаправление на определенную страницу.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync(); // Удаление аутентификационных куков.

            _logger.LogInformation(UserSuccessfulEvents.LogoffUserItem, UserLoggerConstants.USER_IS_LOGOFF);

            return RedirectToAction("Index", "Home");
        }
    }
}
