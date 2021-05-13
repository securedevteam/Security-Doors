using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Logic.Helpers;
using Secure.SecurityDoors.Logic.Models;
using System;
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
        /// <param name="pageFilter">Pagination.</param>
        /// <param name="dateFilter">Date filter.</param>
        /// <param name="dateRangeFilter">Date filter.</param>
        /// <param name="cardIds">Card identifiers filter.</param>
        /// <param name="doorIds">Door identifiers filter.</param>
        /// <param name="userIds">User identifiers filter.</param>
        /// <param name="statusFilter">Status filter.</param>
        /// <param name="includes">Array of includes.</param>
        /// <returns>Get all door action data transfer objects.</returns>
        Task<IEnumerable<DoorActionDto>> GetAllAsync(
            PageHelper pageFilter = default,
            DateTime? dateFilter = default,
            DateRangeHelper dateRangeFilter = default,
            IList<int> cardIds = default,
            IList<int> doorIds = default,
            IList<string> userIds = default,
            DoorActionStatusType? statusFilter = default,
            params string[] includes);

        /// <summary>
        /// Get total count.
        /// </summary>
        /// <param name="dateFilter">Date filter.</param>
        /// <param name="cardIds">Card identifiers filter.</param>
        /// <returns>Number.</returns>
        Task<int> GetTotalCountAsync(
            DateTime? dateFilter = default,
            IList<int> cardIds = default);
    }
}
