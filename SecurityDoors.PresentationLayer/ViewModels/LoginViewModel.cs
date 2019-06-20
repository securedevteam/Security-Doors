using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    /// <summary>
    /// Модель формы авторизации.
    /// </summary>
    public class LoginViewModel
    {       
        /// <summary>
        /// Электронный адрес.
        /// </summary>
        [Required(ErrorMessage = "Неверный электронный адрес")]
        [Display(Name = "Электронный адрес")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Required(ErrorMessage = "Неверный пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        /// <summary>
        /// Запомнить.
        /// </summary>
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Вернуться по определенному адресу.
        /// </summary>
        public string ReturnUrl { get; set; }  
    }
}
