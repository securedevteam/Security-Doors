using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Paginations
{
    public class PersonIndexViewModel
    {
        public IEnumerable<PersonViewModel> People { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
