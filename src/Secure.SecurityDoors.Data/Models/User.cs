using Microsoft.AspNetCore.Identity;
using Secure.SecurityDoors.Data.Enums;
using System.Collections.Generic;

namespace Secure.SecurityDoors.Data.Models
{
    /// <summary>
    /// User by AspNetCore Identity.
    /// </summary>
    public class User : IdentityUser
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

        /// <summary>
        /// Is active now.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Navigation for Cards.
        /// </summary>
        public ICollection<Card> Cards { get; set; }
    }
}
