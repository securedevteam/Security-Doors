using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Paginations
{
    public class CardIndexViewModel
    {
        public IEnumerable<CardViewModel> Cards { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
