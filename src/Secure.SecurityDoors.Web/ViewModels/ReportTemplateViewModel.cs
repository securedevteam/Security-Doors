using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
