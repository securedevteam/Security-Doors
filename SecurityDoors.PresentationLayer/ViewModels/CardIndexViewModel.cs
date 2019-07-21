using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.ViewModels
{
    public class CardIndexViewModel
    {
        public IEnumerable<CardViewModel> Cards { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
