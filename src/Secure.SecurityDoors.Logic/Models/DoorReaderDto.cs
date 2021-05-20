using Secure.SecurityDoors.Data.Enums;

namespace Secure.SecurityDoors.Logic.Models
{
    /// <summary>
    /// DoorReader data transfer object.
    /// </summary>
    public class DoorReaderDto
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
        /// Door data transfer object.
        /// </summary>
        public DoorDto Door { get; set; }
    }
}
