using Secure.SecurityDoors.Data.Enums;

namespace Secure.SecurityDoors.Logic.Models
{
    /// <summary>
    /// Card data transfer object.
    /// </summary>
    public class CardDto
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
        /// Number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Level.
        /// </summary>
        public LevelType Level { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public CardStatusType Status { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; }
    }
}
