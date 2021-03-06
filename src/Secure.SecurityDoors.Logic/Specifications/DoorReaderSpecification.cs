﻿using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using System.Collections.Generic;
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
        /// Apply filter by serial number.
        /// </summary>
        /// <param name="doorReaderQuery">Query.</param>
        /// <param name="serialNumbers">Serial numbers filter.</param>
        /// <returns>Card query.</returns>
        public static IQueryable<DoorReader> ApplyFilterBySerialNumbers(
            this IQueryable<DoorReader> doorReaderQuery,
            IList<string> serialNumbers) =>
                serialNumbers is not null && serialNumbers.Any()
                    ? doorReaderQuery.Where(doorReader => serialNumbers.Contains(doorReader.SerialNumber))
                    : doorReaderQuery;

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
    }
}
