using Microsoft.AspNetCore.Identity;
using SecurityDoors.DataAccessLayer.Models;
using System.Threading.Tasks;

namespace SecurityDoors.DataAccessLayer.InitialDbData
{
    /// <summary>
    /// Класс для заполнения данными пустую базу данных AspNet (Identity).
    /// </summary>
    public class DbInitializerRoles
    {
        /// <summary>
        /// Заполнение первоначальными данными.
        /// </summary>
        /// <param name="userManager">менеджер пользователя.</param>
        /// <param name="roleManager">менеджер роли.</param>
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (await roleManager.FindByNameAsync("moderator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("moderator"));
            }

            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }

            if (await roleManager.FindByNameAsync("visitor") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("visitor"));
            }

            var adminEmail = "admin@admin";
            var adminPassword = "qweQWE1-";

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail, Nickname = "admin" };
                var result = await userManager.CreateAsync(admin, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
