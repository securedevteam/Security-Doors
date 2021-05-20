using System;
using System.Diagnostics.CodeAnalysis;

namespace Secure.SecurityDoors.Logic.Exceptions
{
    /// <summary>
    /// Not found exception.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="message">Message.</param>
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
