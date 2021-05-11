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
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Second name.
        /// </summary>
        [Required]
        [Display(Name = "SecondName")]
        public string SecondName { get; set; }

        /// <summary>
        /// Gender.
        /// </summary>
        [Required]
        [Display(Name = "Gender")]
        public GenderType Gender { get; set; }

        /// <summary>
        /// Passport.
        /// </summary>
        [Required]
        [Display(Name = "Passport")]
        public string Passport { get; set; }

        /// <summary>
        /// Identification number.
        /// </summary>
        [Required]
        [Display(Name = "IdentificationNumber")]
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Role.
        /// </summary>
        [Required]
        [Display(Name = "Role")]
        public RoleType Role { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        [Display(Name = "Comment")]
        public string Comment { get; set; }
    }
}
