using System;
using System.Diagnostics.CodeAnalysis;

namespace Secure.SecurityDoors.Logic.Exceptions
{
    /// <summary>
    /// Conflict exception.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ConflictException : Exception
    {
        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="message">Message.</param>
        public ConflictException(string message)
            : base(message)
        {
        }
    }
}
