namespace Secure.SecurityDoors.Api.Contracts.Requests
{
    /// <summary>
    /// Passage request.
    /// </summary>
    public class PassageRequest
    {
        /// <summary>
        /// Card unique number.
        /// </summary>
        public string CardUniqueNumber { get; set; }

        /// <summary>
        /// DoorReader serial number.
        /// </summary>
        public string DoorReaderSerialNumber { get; set; }
    }
}
