﻿using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Secure.SecurityDoors.Logic.Specifications
{
    /// <summary>
    /// DoorAction specification.
    /// </summary>
    [ExcludeFromCodeCoverage]
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
        /// Apply includes for DoorActionQuery.
        /// </summary>
        /// <param name="doorActionQuery">Query.</param>
        /// <param name="includes">Array of includes.</param>
        /// <returns>DoorAction query.</returns>
        public static IQueryable<DoorAction> Includes(
            this IQueryable<DoorAction> doorActionQuery,
            string[] includes)
        {
            if (includes.Contains(nameof(DoorActionDto.Card)))
            {
                doorActionQuery = doorActionQuery.Include(doorAction => doorAction.Card);
            }

            if (includes.Contains(nameof(DoorActionDto.DoorReader)))
            {
                doorActionQuery = doorActionQuery.Include(doorAction => doorAction.DoorReader);
            }

            if (includes.Contains(nameof(DoorReader.Door)))
            {
                doorActionQuery = doorActionQuery
                    .Include(doorAction => doorAction.DoorReader)
                        .ThenInclude(doorReader => doorReader.Door);
            }

            return doorActionQuery;
        }

        /// <summary>
        /// Apply pagination for DoorActionQuery.
        /// </summary>
        /// <param name="doorActionQuery">Query.</param>
        /// <param name="pageDto">Page data transfer object.</param>
        /// <returns>DoorAction query.</returns>
        public static IQueryable<DoorAction> ApplyPagination(
            this IQueryable<DoorAction> doorActionQuery,
            PageDto pageDto) =>
                pageDto is not null
                    ? doorActionQuery.Skip((pageDto.Page - 1) * pageDto.PageSize)
                        .Take(pageDto.PageSize)
                    : doorActionQuery;

        /// <summary>
        /// Apply filter by date.
        /// </summary>
        /// <param name="doorActionQuery">Query.</param>
        /// <param name="dateFilter">Date filter.</param>
        /// <returns>DoorAction query.</returns>
        public static IQueryable<DoorAction> ApplyFilterByDate(
            this IQueryable<DoorAction> doorActionQuery,
            DateTime? dateFilter) =>
                dateFilter.HasValue && dateFilter.Value.Date != DateTime.MinValue.Date
                    ? doorActionQuery.Where(doorAction => doorAction.TimeStamp.Date == dateFilter.Value.Date)
                    : doorActionQuery;

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
        /// Apply filter by card identifiers.
        /// </summary>
        /// <param name="doorActionQuery">Query.</param>
        /// <param name="cardIds">Card identifiers filter.</param>
        /// <returns>DoorAction query.</returns>
        public static IQueryable<DoorAction> ApplyFilterByCardIds(
            this IQueryable<DoorAction> doorActionQuery,
            IList<int> cardIds) =>
                cardIds is not null && cardIds.Any()
                    ? doorActionQuery.Where(doorAction => cardIds.Contains(doorAction.CardId))
                    : doorActionQuery;

        /// <summary>
        /// Apply filter by door identifiers.
        /// </summary>
        /// <param name="doorActionQuery">Query.</param>
        /// <param name="doorIds">Door identifiers filter.</param>
        /// <returns>DoorAction query.</returns>
        public static IQueryable<DoorAction> ApplyFilterByDoorIds(
            this IQueryable<DoorAction> doorActionQuery,
            IList<int> doorIds) =>
                doorIds is not null && doorIds.Any()
                    ? doorActionQuery
                        .Include(doorAction => doorAction.DoorReader)
                        .Where(doorAction => doorIds.Contains(doorAction.DoorReader.DoorId))
                    : doorActionQuery;
    }
}
