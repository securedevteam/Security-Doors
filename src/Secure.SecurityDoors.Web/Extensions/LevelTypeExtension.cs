using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Web.Constants;

namespace Secure.SecurityDoors.Web.Extensions
{
    /// <summary>
    /// Level type extension.
    /// </summary>
    public static class LevelTypeExtension
    {
        /// <summary>
        /// Convert to role.
        /// </summary>
        /// <param name="levelType">Level type.</param>
        /// <returns>Role.</returns>
        public static string ConvertToRole(this LevelType levelType)
        {
            return levelType switch
            {
                LevelType.Unknown => RoleConstant.Unknown,
                LevelType.Admin => RoleConstant.Admin,
                LevelType.Employee => RoleConstant.Employee,
                LevelType.Manager => RoleConstant.Manager,
                LevelType.Intern => RoleConstant.Intern,
                LevelType.Visitor => RoleConstant.Visitor,
                LevelType.Other => RoleConstant.Other,
                _ => RoleConstant.Unknown,
            };
        }
    }
}
