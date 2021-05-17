using System;
using System.Diagnostics.CodeAnalysis;

namespace Secure.SecurityDoors.Logic.Exceptions
{
    /// <summary>
    /// Application exception.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AppException : Exception
    {
        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="message">Message.</param>
        public AppException(string message)
            : base(message)
        {
        }
    }
}
