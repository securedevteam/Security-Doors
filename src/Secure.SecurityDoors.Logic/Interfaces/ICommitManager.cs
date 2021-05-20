using System.Threading.Tasks;

namespace Secure.SecurityDoors.Logic.Interfaces
{
    /// <summary>
    /// Commit manager.
    /// </summary>
    public interface ICommitManager
    {
        /// <summary>
        /// Save to database.
        /// </summary>
        Task SaveAsync();
    }
}
