using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Logic.Interfaces
{
    /// <summary>
    /// Card manager.
    /// </summary>
    public interface ICardManager
    {
        /// <summary>
        /// Add card.
        /// </summary>
        /// <param name="cardDto">Card data transfer object.</param>
        Task AddAsync(CardDto cardDto);

        /// <summary>
        /// Get all cards.
        /// </summary>
        /// <param name="statusFilter">Status filter.</param>
        /// <param name="levelFilter">Level type filter.</param>
        /// <param name="employeeIds">Employee identifiers filter.</param>
        /// <returns>Get all card data transfer objects.</returns>
        Task<IEnumerable<CardDto>> GetAllAsync(
            CardStatusType? statusFilter = default,
            LevelType? levelFilter = default,
            IList<string> employeeIds = default);

        /// <summary>
        /// Update card.
        /// </summary>
        /// <param name="cardDto">Card data transfer object.</param>
        Task UpdateAsync(CardDto cardDto);

        /// <summary>
        /// Delete card.
        /// </summary>
        /// <param name="id">Card identifier.</param>
        Task DeleteAsync(int id);
    }
}
