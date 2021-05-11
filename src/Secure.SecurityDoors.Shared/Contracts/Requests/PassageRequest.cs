using System.ComponentModel.DataAnnotations;

namespace Secure.SecurityDoors.Shared.Contracts.Requests
{
    /// <summary>
    /// Passage request.
    /// </summary>
    public class PassageRequest
    {
        /// <summary>
        /// Card unique number.
        /// </summary>
        [Required]
        public string CardUniqueNumber { get; set; }

        /// <summary>
        /// DoorReader serial number.
        /// </summary>
        [Required]
        public string DoorReaderSerialNumber { get; set; }
    }
}
