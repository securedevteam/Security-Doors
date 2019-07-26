using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Paginations
{
    public class PersonIndexViewModel
    {
        public IEnumerable<PersonViewModel> People { get; set; }
        public PageViewModel PageViewModel { get; set; }

        /// <summary>
        /// Список доступных карт.
        /// </summary>
        //[Display(Name = "Список доступных уникальных номеров карт")]
        public List<string> AvailableCards { get; set; }
    }
}
