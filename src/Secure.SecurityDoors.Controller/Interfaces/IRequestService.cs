using Secure.SecurityDoors.Shared.Contracts.Requests;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Controller.Interfaces
{
    /// <summary>
    /// Request service.
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// Send.
        /// </summary>
        /// <param name="request">Passage request.</param>
        /// <param name="url">Full url.</param>
        /// <param name="segments">Path segments.</param>
        /// <returns>Result message.</returns>
        Task<string> SendAsync(
            PassageRequest request,
            string url,
            params string[] segment);
    }
}
