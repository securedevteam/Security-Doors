using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Paginations
{
    /// <summary>
    /// Комбинированная модель для сотрудников.
    /// </summary>
    public class PersonIndexViewModel
    {
        /// <summary>
        /// Перечисление с ViewModels сотрудниками.
        /// </summary>
        public IEnumerable<PersonViewModel> People { get; set; }

        /// <summary>
        /// Постраничная навигация.
        /// </summary>
        public PageViewModel PageViewModel { get; set; }

        /// <summary>
        /// Список доступных карт.
        /// </summary>
        public List<string> AvailableCards { get; set; }
    }
}
