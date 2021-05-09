using Microsoft.AspNetCore.Authorization;

namespace Secure.SecurityDoors.Web.Attributes
{
    /// <summary>
    /// Authorize roles attribute.
    /// </summary>
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="roles">Roles.</param>
        public AuthorizeRolesAttribute(params string[] roles)
        {
            Roles = string.Join(",", roles);
        }
    }
}
