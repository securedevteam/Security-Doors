using System;

namespace Secure.SecurityDoors.Web.ViewModels
{
    /// <summary>
    /// Page view model.
    /// </summary>
    public class PageViewModel
    {
        /// <summary>
        /// Number.
        /// </summary>
        public int PageNumber { get; private set; }

        /// <summary>
        /// Total.
        /// </summary>
        public int TotalSize { get; private set; }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="count">Count.</param>
        /// <param name="number">Number.</param>
        /// <param name="size">Size.</param>
        public PageViewModel(int count, int number, int size)
        {
            PageNumber = number;
            TotalSize = (int)Math.Ceiling(count / (double)size);
        }

        /// <summary>
        /// Has previous page.
        /// </summary>
        public bool HasPreviousPage {
            get {
                return (PageNumber > 1);
            }
        }

        /// <summary>
        /// Has next page.
        /// </summary>
        public bool HasNextPage {
            get {
                return (PageNumber < TotalSize);
            }
        }
    }
}
