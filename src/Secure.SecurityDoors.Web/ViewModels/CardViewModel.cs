using Secure.SecurityDoors.Data.Enums;

namespace Secure.SecurityDoors.Web.ViewModels
{
    /// <summary>
    /// Card view model.
    /// </summary>
    public class CardViewModel
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
        /// Comment.
        /// </summary>
        public string Comment { get; set; }
    }
}
