using Secure.SecurityDoors.Data.Enums;

namespace Secure.SecurityDoors.Web.ViewModels
{
    /// <summary>
    /// Profile view model.
    /// </summary>
    public class ProfileViewModel
    {
        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Second name.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Gender.
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Passport.
        /// </summary>
        public string Passport { get; set; }

        /// <summary>
        /// Identification number.
        /// </summary>
        public string IdentificationNumber { get; set; }
    }
}
