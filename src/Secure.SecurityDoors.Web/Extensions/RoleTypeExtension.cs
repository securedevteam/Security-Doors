using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Web.Constants;

namespace Secure.SecurityDoors.Web.Extensions
{
    /// <summary>
    /// Role type extension.
    /// </summary>
    public static class RoleTypeExtension
    {
        /// <summary>
        /// Convert RoleType to RoleConstant.
        /// </summary>
        /// <param name="roleType">Role type.</param>
        /// <returns>Role.</returns>
        public static string ConvertToConstant(this RoleType roleType)
        {
            return roleType switch
            {
                RoleType.Unknown => RoleConstant.Unknown,
                RoleType.Admin => RoleConstant.Admin,
                RoleType.Employee => RoleConstant.Employee,
                RoleType.Manager => RoleConstant.Manager,
                RoleType.Intern => RoleConstant.Intern,
                RoleType.Visitor => RoleConstant.Visitor,
                _ => RoleConstant.Unknown,
            };
        }
    }
}
