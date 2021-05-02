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
        /// Constructor.
        /// </summary>
        public NotFoundException()
            : base()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Message.</param>
        public NotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="key">Key.</param>
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
