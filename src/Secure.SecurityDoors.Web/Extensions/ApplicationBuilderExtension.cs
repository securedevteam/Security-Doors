using Microsoft.AspNetCore.Builder;
using Secure.SecurityDoors.Web.Middlewares;
using System;

namespace Secure.SecurityDoors.Web.Extensions
{
    /// <summary>
    /// Application builer extension.
    /// </summary>
    public static class ApplicationBuilderExtension
    {
        /// <summary>
        /// Custom error handler.
        /// </summary>
        /// <param name="app">Application builder.</param>
        /// <returns>Application builder with custom error handler.</returns>
        public static IApplicationBuilder UseCustomPageNotFoundHandler(this IApplicationBuilder app)
        {
            app = app ?? throw new ArgumentNullException(nameof(app));

            app.UseMiddleware<PageNotFoundMiddleware>();

            return app;
        }
    }
}
