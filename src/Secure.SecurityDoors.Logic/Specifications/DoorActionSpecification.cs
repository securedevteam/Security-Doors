﻿using Microsoft.EntityFrameworkCore;
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
        /// Apply filter by door action status.
        /// </summary>
        /// <param name="doorActionQuery">Query.</param>
        /// <param name="statusFilter">Status filter.</param>
        /// <returns>DoorAction query.</returns>
        public static IQueryable<DoorAction> ApplyFilterByStatus(
            this IQueryable<DoorAction> doorActionQuery,
            DoorActionStatusType? statusFilter) =>
                statusFilter.HasValue
                    ? doorActionQuery.Where(doorAction => doorAction.Status == statusFilter)
                    : doorActionQuery;

        /// <summary>
        /// Apply filter by door action type.
        /// </summary>
        /// <param name="doorActionQuery">Query.</param>
        /// <param name="typeFilter">Type filter.</param>
        /// <returns>DoorAction query.</returns>
        public static IQueryable<DoorAction> ApplyFilterByType(
            this IQueryable<DoorAction> doorActionQuery,
            DoorActionType? typeFilter) =>
                typeFilter.HasValue
                    ? doorActionQuery.Where(doorAction => doorAction.Type == typeFilter)
                    : doorActionQuery;

    }
}
