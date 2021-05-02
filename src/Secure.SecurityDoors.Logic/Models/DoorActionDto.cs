using Secure.SecurityDoors.Data.Enums;
using System;

namespace Secure.SecurityDoors.Logic.Models
{
    /// <summary>
    /// DoorAction data transfer object.
    /// </summary>
    public class DoorActionDto
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Door identifier.
        /// </summary>
        public int DoorId { get; set; }

        /// <summary>
        /// Card identifier.
        /// </summary>
        public int CardId { get; set; }

        /// <summary>
        /// Time stamp.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public DoorActionStatusType Status { get; set; }

        /// <summary>
        /// Is entrance.
        /// </summary>
        public bool? IsEntrance { get; set; }
    }
}
