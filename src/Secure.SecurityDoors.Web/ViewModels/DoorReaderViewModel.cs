using Secure.SecurityDoors.Data.Enums;

namespace Secure.SecurityDoors.Web.ViewModels
{
    /// <summary>
    /// DoorReader view model.
    /// </summary>
    public class DoorReaderViewModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Serial number.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Door identifier.
        /// </summary>
        public int DoorId { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public DoorReaderType Type { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Door view model.
        /// </summary>
        public DoorViewModel Door { get; set; }
    }
}
