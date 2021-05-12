using System.Collections.Generic;

namespace Secure.SecurityDoors.Web.ViewModels
{
    /// <summary>
    /// DoorAction index view model.
    /// </summary>
    public class DoorActionIndexViewModel
    {
        /// <summary>
        /// DoorAction view models items.
        /// </summary>
        public IEnumerable<DoorActionViewModel> DoorActionViewModels { get; set; }

        /// <summary>
        /// Page view model.
        /// </summary>
        public PageViewModel PageViewModel { get; set; }

        /// <summary>
        /// Date filter.
        /// </summary>
        public string DateFilter { get; set; }
    }
}
