using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using System.Linq;

namespace Secure.SecurityDoors.Logic.Specifications
{
    /// <summary>
    /// DoorAction specification.
    /// </summary>
    public static class DoorActionSpecification
    {
        /// <summary>
        /// DoorAction query with no tracking.
        /// </summary>
        /// <param name="doorActionDbSet">Database set of DoorAction.</param>
        /// <param name="withNoTracking">With no tracking.</param>
        /// <returns>DoorAction query.</returns>
        public static IQueryable<DoorAction> GetDoorActionQuery(
            this DbSet<DoorAction> doorActionDbSet,
            bool withNoTracking) => 
                withNoTracking
                    ? doorActionDbSet.AsNoTracking()
                    : doorActionDbSet;

        /// <summary>
        /// Apply filter by door action type.
        /// </summary>
        /// <param name="doorActionQuery">DoorAction query.</param>
        /// <param name="filterDoorActionType">Filter by type.</param>
        /// <returns>DoorAction query.</returns>
        public static IQueryable<DoorAction> ApplyFilterByType(
            this IQueryable<DoorAction> doorActionQuery,
            DoorActionType? filterDoorActionType) =>
                filterDoorActionType.HasValue
                    ? doorActionQuery.Where(doorAction => doorAction.Type == filterDoorActionType)
                    : doorActionQuery;

        /// <summary>
        /// Apply filter by door action status type.
        /// </summary>
        /// <param name="doorActionQuery">DoorAction query.</param>
        /// <param name="filterDoorActionStatusType">Filter by status type.</param>
        /// <returns>DoorAction query.</returns>
        public static IQueryable<DoorAction> ApplyFilterByStatus(
            this IQueryable<DoorAction> doorActionQuery,
            DoorActionStatusType? filterDoorActionStatusType) =>
                filterDoorActionStatusType.HasValue
                    ? doorActionQuery.Where(doorAction => doorAction.Status == filterDoorActionStatusType)
                    : doorActionQuery;

    }
}
