using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Logic.Interfaces
{
    /// <summary>
    /// DoorAction manager.
    /// </summary>
    public interface IDoorActionManager
    {
        /// <summary>
        /// Add door action.
        /// </summary>
        /// <param name="doorActionDto">Door action data transfer object.</param>
        Task AddAsync(DoorActionDto doorActionDto);

        /// <summary>
        /// Get all door actions.
        /// </summary>
        /// <param name="statusFilter">Status filter.</param>
        /// <returns>Get all door action data transfer objects.</returns>
        Task<IEnumerable<DoorActionDto>> GetAllAsync(
            DoorActionStatusType? statusFilter = default);

        /// <summary>
        /// Get door by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="statusFilter">Status filter.</param>
        /// <returns>Get door action data transfer object.</returns>
        Task<DoorActionDto> GetByIdAsync(
            int id,
            DoorActionStatusType? statusFilter = default);
    }
}
