using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using System.Linq;

namespace Secure.SecurityDoors.Logic.Specifications
{
    /// <summary>
    /// Card specification.
    /// </summary>
    public static class CardSpecification
    {
        /// <summary>
        /// Card query with no tracking.
        /// </summary>
        /// <param name="cardDbSet">Database set of Card.</param>
        /// <param name="withNoTracking">With no tracking.</param>
        /// <returns>Card query.</returns>
        public static IQueryable<Card> GetCardQuery(
            this DbSet<Card> cardDbSet,
            bool withNoTracking) =>
                withNoTracking
                    ? cardDbSet.AsNoTracking()
                    : cardDbSet;

        /// <summary>
        /// Apply filter by card status.
        /// </summary>
        /// <param name="cardQuery">Query.</param>
        /// <param name="statusFilter">Status type filter.</param>
        /// <returns>Card query.</returns>
        public static IQueryable<Card> ApplyFilterByStatus(
            this IQueryable<Card> cardQuery,
            CardStatusType? statusFilter) =>
                statusFilter.HasValue
                    ? cardQuery.Where(card => card.Status == statusFilter)
                    : cardQuery;

        /// <summary>
        /// Apply filter by card level.
        /// </summary>
        /// <param name="cardQuery">Query.</param>
        /// <param name="levelFilter">Level filter.</param>
        /// <returns>Card query.</returns>
        public static IQueryable<Card> ApplyFilterByLevel(
            this IQueryable<Card> cardQuery,
            LevelType? levelFilter) =>
                levelFilter.HasValue
                    ? cardQuery.Where(card => card.Level == levelFilter)
                    : cardQuery;
    }
}
