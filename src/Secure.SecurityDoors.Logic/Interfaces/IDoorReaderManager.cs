using Secure.SecurityDoors.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Logic.Interfaces
{
    /// <summary>
    /// DoorReader manager.
    /// </summary>
    public interface IDoorReaderManager
    {
        /// <summary>
        /// Get all door readers.
        /// </summary>
        /// <param name="serialNumbers">Serial numbers filter.</param>
        /// <param name="includes">Array of includes.</param>
        /// <returns>Get all door reader data transfer objects.</returns>
        Task<IEnumerable<DoorReaderDto>> GetAllAsync(
            IList<string> serialNumbers = default,
            params string[] includes);
    }
}
