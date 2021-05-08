using Secure.SecurityDoors.Data.Enums;

namespace Secure.SecurityDoors.Web.ViewModels
{
    /// <summary>
    /// Door view model.
    /// </summary>
    public class DoorViewModel
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
