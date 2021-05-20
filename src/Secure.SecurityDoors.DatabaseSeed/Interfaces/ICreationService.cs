using System.Threading.Tasks;

namespace Secure.SecurityDoors.DatabaseSeed.Interfaces
{
    /// <summary>
    /// Creation service.
    /// </summary>
    public interface ICreationService
    {
        /// <summary>
        /// Create user.
        /// </summary>
        Task CreateUser();

        /// <summary>
        /// Create role.
        /// </summary>
        Task CreateRole();
    }
}
