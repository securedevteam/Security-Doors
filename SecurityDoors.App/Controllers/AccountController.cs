using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Threading.Tasks;

namespace SecurityDoors.App.Controllers
{
    /// <summary>
    /// Контроллер для работы с аккаунтом пользователя.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="singInManager">менеджер входа в систему.</param>
        public AccountController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        /// <summary>
        /// Вход в систему.
        /// </summary>
        /// <param name="returnUrl">возврат по определенному адресу.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Authorization(string returnUrl = null)
        {
            return View(new AuthorizationViewModel { ReturnUrl = returnUrl });
        }

        /// <summary>
        /// Вход в систему.
        /// </summary>
        /// <param name="model">модель пользовательских данных.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authorization(AuthorizationViewModel model)
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
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
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
            return RedirectToAction("Index", "Home");
        }
    }
}
