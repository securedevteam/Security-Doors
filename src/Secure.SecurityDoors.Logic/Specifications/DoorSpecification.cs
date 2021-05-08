using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Models;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Secure.SecurityDoors.Logic.Specifications
{
    /// <summary>
    /// Door specification.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DoorSpecification
    {
        /// <summary>
        /// Door query with no tracking.
        /// </summary>
        /// <param name="doorDbSet">Database set of Door.</param>
        /// <param name="withNoTracking">With no tracking.</param>
        /// <returns>Door query.</returns>
        public static IQueryable<Door> GetDoorQuery(
            this DbSet<Door> doorDbSet,
            bool withNoTracking) =>
                withNoTracking
                    ? doorDbSet.AsNoTracking()
                    : doorDbSet;
    }
}
