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
        /// DoorReader identifier.
        /// </summary>
        public int DoorReaderId { get; set; }

        /// <summary>
        /// Card identifier.
        /// </summary>
        public int CardId { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public DoorActionStatusType Status { get; set; }

        /// <summary>
        /// Time stamp.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Card data transfer object.
        /// </summary>
        public CardDto Card { get; set; }

        /// <summary>
        /// DoorReader data transfer object.
        /// </summary>
        public DoorReaderDto DoorReader { get; set; }
    }
}
