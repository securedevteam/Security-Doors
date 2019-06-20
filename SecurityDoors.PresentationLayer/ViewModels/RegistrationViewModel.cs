using System.ComponentModel.DataAnnotations;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    /// <summary>
    /// Модель формы регистрации.
    /// </summary>
    public class RegistrationViewModel
    {
        /// <summary>
        /// Электронный адрес.
        /// </summary>
        [Required(ErrorMessage = "Неверный электронный адрес")]
        [Display(Name = "Электронный адрес")]
        public string Email { get; set; }

        /// <summary>
        /// Псевдоним.
        /// </summary>
        [Required(ErrorMessage = "Недопустимый псевдоним")]
        [Display(Name = "Псевдоним")]
        public int Nickname { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Required(ErrorMessage = "Неверный пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        /// <summary>
        /// Подтвердить пароль.
        /// </summary>
        [Required(ErrorMessage = "Неверный пароль")]
        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
