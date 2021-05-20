using System.Collections.Generic;

namespace Secure.SecurityDoors.Web.ViewModels
{
    /// <summary>
    /// Report template view model.
    /// </summary>
    public class ReportTemplateViewModel
    {
        /// <summary>
        /// DoorAction view models items.
        /// </summary>
        public IEnumerable<DoorActionViewModel> DoorActionViewModels { get; set; }
    }
}
