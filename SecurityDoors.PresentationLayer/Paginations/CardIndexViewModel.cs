using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Paginations
{
    /// <summary>
    /// Комбинированная модель для карточек.
    /// </summary>
    public class CardIndexViewModel
    {
        /// <summary>
        /// Перечисление с ViewModels карточками.
        /// </summary>
        public IEnumerable<CardViewModel> Cards { get; set; }

        /// <summary>
        /// Постраничная навигация.
        /// </summary>
        public PageViewModel PageViewModel { get; set; }
    }
}
