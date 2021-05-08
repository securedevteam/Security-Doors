using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        /// Date.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
