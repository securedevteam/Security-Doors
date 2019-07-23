using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Paginations
{
    public class DoorIndexViewModel
    {
        public IEnumerable<DoorViewModel> Doors { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
