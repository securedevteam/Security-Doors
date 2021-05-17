using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Web.Middlewares
{
    /// <summary>
    /// Page not found middleware.
    /// </summary>
    public class PageNotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="next">Request delegate.</param>
        public PageNotFoundMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Invoke.
        /// </summary>
        /// <param name="context">Http context.</param>
        public async Task Invoke(HttpContext context)
        {
            context = context ?? throw new ArgumentNullException(nameof(context));

            await _next(context);

            if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
            {
                context.Request.Path = "/Error/404";
                await _next(context);
            }
        }
    }
}
