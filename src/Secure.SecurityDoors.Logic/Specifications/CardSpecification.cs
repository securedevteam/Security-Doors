using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Secure.SecurityDoors.Logic.Specifications
{
    /// <summary>
    /// Card specification.
    /// </summary>
    [ExcludeFromCodeCoverage]
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
        /// Apply filter by employee identifiers.
        /// </summary>
        /// <param name="cardQuery">Query.</param>
        /// <param name="employeeIds">Employee identifiers filter.</param>
        /// <returns>Card query.</returns>
        public static IQueryable<Card> ApplyFilterByEmployeeIds(
            this IQueryable<Card> cardQuery,
            IList<string> employeeIds) =>
                employeeIds is not null && employeeIds.Any()
                    ? cardQuery.Where(card => employeeIds.Contains(card.UserId))
                    : cardQuery;

        /// <summary>
        /// Apply filter by unique numbers.
        /// </summary>
        /// <param name="cardQuery">Query.</param>
        /// <param name="uniqueNumbers">Unique numbers filter.</param>
        /// <returns>Card query.</returns>
        public static IQueryable<Card> ApplyFilterByUniqueNumbers(
            this IQueryable<Card> cardQuery,
            IList<string> uniqueNumbers) =>
                uniqueNumbers is not null && uniqueNumbers.Any()
                    ? cardQuery.Where(card => uniqueNumbers.Contains(card.UniqueNumber))
                    : cardQuery;

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
