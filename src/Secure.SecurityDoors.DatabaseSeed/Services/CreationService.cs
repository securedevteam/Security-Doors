using Microsoft.AspNetCore.Identity;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.DatabaseSeed.Interfaces;
using System;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.DatabaseSeed.Services
{
    public class CreationService : ICreationService
    {
        public readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreationService(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public async Task CreateRole()
        {
            var role = ConsoleInput("role");
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Role already exist.");
            }
        }

        public async Task CreateUser()
        {
            var email = ConsoleInput("email");
            var userName = ConsoleInput("username");
            var firstName = ConsoleInput("first name");
            var lastName = ConsoleInput("last name");
            var secondName = ConsoleInput("second name");
            var gender = ConsoleInput("gender");
            var passport = ConsoleInput("passport");
            var identificationNumber = ConsoleInput("identification number");
            var comment = ConsoleInput("comment");
            var password = ConsoleInput("password");
            var role = ConsoleInput("role");

            var user = new User
            {
                Email = email,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                SecondName = secondName,
                Gender = Enum.Parse<GenderType>(gender),
                Passport = passport,
                IdentificationNumber = identificationNumber,
                Comment = comment,
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.Description);
                }
            }
            else
            {
                await _userManager.AddToRoleAsync(user, role);

                Console.WriteLine("Done.");
            }
        }

        private static string ConsoleInput(string type)
        {
            Console.Write($"Enter {type}: ");
            return Console.ReadLine();
        }
    }
}
