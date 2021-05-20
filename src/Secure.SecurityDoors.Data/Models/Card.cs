using Secure.SecurityDoors.Data.Enums;
using System;
using System.Collections.Generic;

namespace Secure.SecurityDoors.Data.Models
{
    /// <summary>
    /// Card entity.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User identifier.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Navigation for User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Unique number.
        /// </summary>
        public string UniqueNumber { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public CardStatusType Status { get; set; }

        /// <summary>
        /// Level.
        /// </summary>
        public LevelType Level { get; set; }

        /// <summary>
        /// Expiration time.
        /// </summary>
        public DateTime ExpirationTime { get; set; }

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
