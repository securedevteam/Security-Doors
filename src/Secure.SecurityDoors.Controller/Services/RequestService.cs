using Flurl;
using Flurl.Http;
using Secure.SecurityDoors.Controller.Interfaces;
using Secure.SecurityDoors.Controller.Resources;
using Secure.SecurityDoors.Shared.Contracts.Requests;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Controller.Services
{
    /// <inheritdoc cref="IRequestService"/>
    public class RequestService : IRequestService
    {
        public async Task<string> SendAsync(
            PassageRequest request,
            string url,
            params string[] segments)
        {
            var message = MessageResource.Success;

            try
            {
                await url.AppendPathSegments(segments)
                    .PostJsonAsync(request);
            }
            catch (FlurlHttpException ex)
            {
                message = ex.Message;
            }

            return message;
        }
    }
}
