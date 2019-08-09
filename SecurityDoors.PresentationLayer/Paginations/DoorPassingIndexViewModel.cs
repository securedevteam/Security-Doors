using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Paginations
{
    /// <summary>
    /// Комбинированная модель для дверных проходов.
    /// </summary>
    public class DoorPassingIndexViewModel
    {
        /// <summary>
        /// Перечисление с ViewModels дверными проходами.
        /// </summary>
        public IEnumerable<DoorPassingViewModel> DoorPassings { get; set; }

        /// <summary>
        /// Постраничная навигация.
        /// </summary>
        public PageViewModel PageViewModel { get; set; }
    }
}
