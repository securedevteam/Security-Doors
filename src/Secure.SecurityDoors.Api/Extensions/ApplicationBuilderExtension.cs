using Microsoft.AspNetCore.Builder;
using Secure.SecurityDoors.Api.Middlewares;
using System;

namespace Secure.SecurityDoors.Api.Extensions
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
        public static IApplicationBuilder UseCustomErrorHandler(this IApplicationBuilder app)
        {
            app = app ?? throw new ArgumentNullException(nameof(app));

            app.UseMiddleware<ErrorHandlerMiddleware>();

            return app;
        }
    }
}
