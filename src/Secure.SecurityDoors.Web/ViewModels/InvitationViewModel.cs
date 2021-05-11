using Secure.SecurityDoors.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Secure.SecurityDoors.Web.ViewModels
{
    /// <summary>
    /// Invitation view model.
    /// </summary>
    public class InvitationViewModel
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required(ErrorMessage = "ErrorMessageEmail")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        [Required(ErrorMessage = "ErrorMessageUsername")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        [Required(ErrorMessage = "ErrorMessageFirstName")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        [Required(ErrorMessage = "ErrorMessageLastName")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Second name.
        /// </summary>
        [Display(Name = "SecondName")]
        public string SecondName { get; set; }

        /// <summary>
        /// Gender.
        /// </summary>
        [Required(ErrorMessage = "ErrorMessageGender")]
        [Display(Name = "Gender")]
        public GenderType Gender { get; set; }

        /// <summary>
        /// Passport.
        /// </summary>
        [Required(ErrorMessage = "ErrorMessagePassport")]
        [Display(Name = "Passport")]
        public string Passport { get; set; }

        /// <summary>
        /// Identification number.
        /// </summary>
        [Required(ErrorMessage = "ErrorMessageIdNumber")]
        [Display(Name = "IdentificationNumber")]
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Role.
        /// </summary>
        [Required(ErrorMessage = "ErrorMessageRole")]
        [Display(Name = "Role")]
        public RoleType Role { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        [Display(Name = "Comment")]
        public string Comment { get; set; }
    }
}
