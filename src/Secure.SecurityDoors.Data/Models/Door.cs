using Secure.SecurityDoors.Data.Enums;
using System.Collections.Generic;

namespace Secure.SecurityDoors.Data.Models
{
    /// <summary>
    /// Door entity.
    /// </summary>
    public class Door
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Level.
        /// </summary>
        public LevelType Level { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public DoorStatusType Status { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Navigation for DoorActions.
        /// </summary>
        public ICollection<DoorAction> DoorActions { get; set; }
    }
}
