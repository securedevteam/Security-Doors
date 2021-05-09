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
        public string Email { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Second name.
        /// </summary>
        [Required]
        public string SecondName { get; set; }

        /// <summary>
        /// Gender.
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Passport.
        /// </summary>
        [Required]
        public string Passport { get; set; }

        /// <summary>
        /// Identification number.
        /// </summary>
        [Required]
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Role.
        /// </summary>
        public RoleType Role { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; }
    }
}
