using Secure.SecurityDoors.Data.Enums;
using System;

namespace Secure.SecurityDoors.Data.Models
{
    /// <summary>
    /// DoorAction entity.
    /// </summary>
    public class DoorAction
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
        /// Navigation for DoorReader.
        /// </summary>
        public DoorReader DoorReader { get; set; }

        /// <summary>
        /// Card identifier.
        /// </summary>
        public int CardId { get; set; }

        /// <summary>
        /// Navigation for Card.
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public DoorActionStatusType Status { get; set; }

        /// <summary>
        /// Time stamp.
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }
}
