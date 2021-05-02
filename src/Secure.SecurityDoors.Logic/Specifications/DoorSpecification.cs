using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using System.Linq;

namespace Secure.SecurityDoors.Logic.Specifications
{
    /// <summary>
    /// Door specification.
    /// </summary>
    public static class DoorSpecification
    {
        /// <summary>
        /// Door query with no tracking.
        /// </summary>
        /// <param name="DoorDbSet">Database set of Door.</param>
        /// <param name="withNoTracking">With no tracking.</param>
        /// <returns>Door query.</returns>
        public static IQueryable<Door> GetDoorQuery(
            this DbSet<Door> DoorDbSet,
            bool withNoTracking) =>
                withNoTracking
                    ? DoorDbSet.AsNoTracking()
                    : DoorDbSet;

        /// <summary>
        /// Apply filter by door status.
        /// </summary>
        /// <param name="doorQuery">Query.</param>
        /// <param name="statusFilter">Status type filter.</param>
        /// <returns>Door query.</returns>
        public static IQueryable<Door> ApplyFilterByStatus(
            this IQueryable<Door> doorQuery,
            DoorStatusType? statusFilter) =>
                statusFilter.HasValue
                    ? doorQuery.Where(door => door.Status == statusFilter)
                    : doorQuery;

        /// <summary>
        /// Apply filter by door level.
        /// </summary>
        /// <param name="doorQuery">Query.</param>
        /// <param name="levelFilter">Level filter.</param>
        /// <returns>Door query.</returns>
        public static IQueryable<Door> ApplyFilterByLevel(
            this IQueryable<Door> doorQuery,
            LevelType? levelFilter) =>
                levelFilter.HasValue
                    ? doorQuery.Where(door => door.Level == levelFilter)
                    : doorQuery;
    }
}
