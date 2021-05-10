using Secure.SecurityDoors.Data.Enums;
using System.Collections.Generic;

namespace Secure.SecurityDoors.Logic.Models
{
    /// <summary>
    /// Door data transfer object.
    /// </summary>
    public class DoorDto
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
        /// Status.
        /// </summary>
        public DoorStatusType Status { get; set; }

        /// <summary>
        /// Level.
        /// </summary>
        public LevelType Level { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; }
    }
}
