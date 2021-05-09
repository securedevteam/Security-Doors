using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Secure.SecurityDoors.Logic.Specifications
{
    /// <summary>
    /// DoorReader specification.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DoorReaderSpecification
    {
        /// <summary>
        /// DoorReader query with no tracking.
        /// </summary>
        /// <param name="doorReaderDbSet">Database set of DoorReader.</param>
        /// <param name="withNoTracking">With no tracking.</param>
        /// <returns>DoorReader query.</returns>
        public static IQueryable<DoorReader> GetDoorReaderQuery(
            this DbSet<DoorReader> doorReaderDbSet,
            bool withNoTracking) =>
                withNoTracking
                    ? doorReaderDbSet.AsNoTracking()
                    : doorReaderDbSet;

        /// <summary>
        /// Apply includes for DoorReaderQuery.
        /// </summary>
        /// <param name="doorReaderQuery">Query.</param>
        /// <param name="includes">Array of includes.</param>
        /// <returns>DoorReader query.</returns>
        public static IQueryable<DoorReader> Includes(
            this IQueryable<DoorReader> doorReaderQuery,
            string[] includes)
        {
            if (includes.Contains(nameof(DoorReader.Door)))
            {
                doorReaderQuery = doorReaderQuery
                    .Include(doorReader => doorReader.Door);
            }

            return doorReaderQuery;
        }

        /// <summary>
        /// Apply filter by door reader type.
        /// </summary>
        /// <param name="doorReaderQuery">Query.</param>
        /// <param name="typeFilter">Type filter.</param>
        /// <returns>DoorReader query.</returns>
        public static IQueryable<DoorReader> ApplyFilterByType(
            this IQueryable<DoorReader> doorReaderQuery,
            DoorReaderType? typeFilter) =>
                typeFilter.HasValue
                    ? doorReaderQuery.Where(doorReader => doorReader.Type == typeFilter)
                    : doorReaderQuery;

        /// <summary>
        /// Apply filter by door status.
        /// </summary>
        /// <param name="doorReaderQuery">Query.</param>
        /// <param name="doorStatusFilter">Door status filter.</param>
        /// <returns>DoorReader query.</returns>
        public static IQueryable<DoorReader> ApplyFilterByDoorStatus(
            this IQueryable<DoorReader> doorReaderQuery,
            DoorStatusType? doorStatusFilter)
        {
            return doorStatusFilter.HasValue
                ? doorReaderQuery
                    .Include(doorReader => doorReader.Door)
                    .Where(doorReader => doorReader.Door.Status == doorStatusFilter)
                : doorReaderQuery;
        }

        /// <summary>
        /// Apply filter by door level.
        /// </summary>
        /// <param name="doorReaderQuery">Query.</param>
        /// <param name="doorLevelType">Door level filter.</param>
        /// <returns>DoorReader query.</returns>
        public static IQueryable<DoorReader> ApplyFilterByDoorLevel(
            this IQueryable<DoorReader> doorReaderQuery,
            LevelType? doorLevelType)
        {
            return doorLevelType.HasValue
                ? doorReaderQuery
                    .Include(doorReader => doorReader.Door)
                    .Where(doorReader => doorReader.Door.Level == doorLevelType)
                : doorReaderQuery;
        }
    }
}
