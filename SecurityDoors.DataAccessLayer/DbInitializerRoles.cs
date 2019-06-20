using Microsoft.AspNetCore.Identity;
using SecurityDoors.DataAccessLayer.Models;
using System.Threading.Tasks;

namespace SecurityDoors.DataAccessLayer
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
            //string adminEmail = "admin@gmail.com";
            //string password = "_Aa123456";

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

            // В случае необходимости можно сразу добавить и пользователя.

            //if (await userManager.FindByNameAsync(adminEmail) == null)
            //{
            //    var admin = new User { Email = adminEmail, UserName = adminEmail };
            //    IdentityResult result = await userManager.CreateAsync(admin, password);
            //    if (result.Succeeded)
            //    {
            //        await userManager.AddToRoleAsync(admin, "admin");
            //    }
            //}
        }
    }
}
