using Microsoft.AspNetCore.Identity;

namespace SecurityDoors.DataAccessLayer.Models
{
    /// <summary>
    /// Расширение модели IdentityUser.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Псевдоним.
        /// </summary>
        public string Nickname { get; set; }
    }
}
