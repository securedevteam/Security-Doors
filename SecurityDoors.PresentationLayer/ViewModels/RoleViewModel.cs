using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    /// <summary>
    /// Модель формы ролей.
    /// </summary>
    public class RoleViewModel
    {
        /// <summary>
        /// Id пользователя.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Электронный ящик пользователя.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Все роли.
        /// </summary>
        public IEnumerable<IdentityRole> AllRoles { get; set; }

        /// <summary>
        /// Пользовательские роли.
        /// </summary>
        public IEnumerable<string> UserRoles { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public RoleViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}
