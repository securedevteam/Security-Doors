using System.ComponentModel.DataAnnotations;

namespace Secure.SecurityDoors.Web.ViewModels
{
    /// <summary>
    /// Login view model.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// User name.
        /// </summary>
        [Required(ErrorMessage = "ErrorMessageUsername")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required(ErrorMessage = "ErrorMessagePassword")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Remember me.
        /// </summary>
        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Return url.
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
