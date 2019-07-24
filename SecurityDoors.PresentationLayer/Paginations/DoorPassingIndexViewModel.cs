using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Paginations
{
    public class DoorPassingIndexViewModel
    {
        public IEnumerable<DoorPassingViewModel> DoorPassings { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
