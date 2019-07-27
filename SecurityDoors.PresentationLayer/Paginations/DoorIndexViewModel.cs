using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Paginations
{
    /// <summary>
    /// Комбинированная модель для дверей.
    /// </summary>
    public class DoorIndexViewModel
    {
        /// <summary>
        /// Перечисление с ViewModels дверьми.
        /// </summary>
        public IEnumerable<DoorViewModel> Doors { get; set; }

        /// <summary>
        /// Постраничная навигация.
        /// </summary>
        public PageViewModel PageViewModel { get; set; }
    }
}
