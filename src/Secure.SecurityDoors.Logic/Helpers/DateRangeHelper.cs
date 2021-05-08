using System;

namespace Secure.SecurityDoors.Logic.Helpers
{
    /// <summary>
    /// Date range helper.
    /// </summary>
    public class DateRangeHelper
    {
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        public DateRangeHelper(DateTime? start = default, DateTime? end = default)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Start.
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// End.
        /// </summary>
        public DateTime? End { get; set; }
    }
}
