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
        /// Add door.
        /// </summary>
        /// <param name="doorDto">Door data transfer object.</param>
        Task AddAsync(DoorDto doorDto);

        /// <summary>
        /// Get all doors.
        /// </summary>
        /// <param name="whereLevelType">Filter by level type.</param>
        /// <param name="whereDoorStatusType">Filter by status type.</param>
        /// <returns>Get all door data transfer objects.</returns>
        Task<IEnumerable<DoorDto>> GetAllAsync(
            LevelType? whereLevelType = default,
            DoorStatusType? whereDoorStatusType = default);

        /// <summary>
        /// Update door.
        /// </summary>
        /// <param name="doorDto">Door data transfer object.</param>
        Task UpdateAsync(DoorDto doorDto);

        /// <summary>
        /// Delete door.
        /// </summary>
        /// <param name="id">Door identifier.</param>
        Task DeleteAsync(int id);
    }
}
