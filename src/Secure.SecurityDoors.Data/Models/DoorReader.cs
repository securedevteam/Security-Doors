using Secure.SecurityDoors.Data.Enums;
using System.Collections.Generic;

namespace Secure.SecurityDoors.Data.Models
{
    /// <summary>
    /// DoorReader entity.
    /// </summary>
    public class DoorReader
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
        /// Navigation for Door.
        /// </summary>
        public Door Door { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public DoorReaderType Type { get; set; }

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
