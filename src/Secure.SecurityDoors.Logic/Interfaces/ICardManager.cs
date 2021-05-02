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
        /// <param name="whereLevelType">Filter by level type.</param>
        /// <param name="whereCardStatusType">Filter by status type.</param>
        /// <returns>Get all card data transfer objects.</returns>
        Task<IEnumerable<CardDto>> GetAllAsync(
            LevelType? whereLevelType = default,
            CardStatusType? whereCardStatusType = default);

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
