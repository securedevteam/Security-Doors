using Microsoft.AspNetCore.Identity;

namespace SecurityDoors.DataAccessLayer.Models
{
    /// <summary>
    /// Расширение модели IdentityUser.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Прозвище.
        /// </summary>
        public int Nickname { get; set; }
    }
}
