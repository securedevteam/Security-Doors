using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Logic.Interfaces
{
    /// <summary>
    /// Door manager.
    /// </summary>
    public interface IDoorManager
    {
        /// <summary>
        /// Get all doors.
        /// </summary>
        /// <param name="statusFilter">Status filter.</param>
        /// <param name="levelFilter">Level type filter.</param>
        /// <returns>Get all door data transfer objects.</returns>
        Task<IEnumerable<DoorDto>> GetAllAsync(
            DoorStatusType? statusFilter = default,
            LevelType? levelFilter = default);
    }
}
