namespace Secure.SecurityDoors.Web.ViewModels
{
    /// <summary>
    /// Error view model.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Request identifier.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Show request identifier.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
