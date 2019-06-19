using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Interfaces
{
    interface IDoorPassingService
    {
        /// <summary>
        /// Получить все проходы.
        /// </summary>
        /// <returns>Список проходов.</returns>
		Task<List<DoorPassingViewModel>> GetDoorPassingsAsync();

        /// <summary>
        /// Получить проход.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Карточка.</returns>
        Task<DoorPassingViewModel> GetDoorPassingByIdAsync(int id);

        /// <summary>
        /// Изменить проход.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Проход.</returns>
        Task<DoorPassingEditModel> EditDoorPassingByIdAsync(int id);

        /// <summary>
        /// Сохранить проход с сигнатурой DoorPassingEditModel.
        /// </summary>
        /// <param name="model">Модель карточки для сохранения.</param>
        /// <returns>Карточка.</returns>
        Task<DoorPassingViewModel> SaveCardAsync(DoorPassingEditModel model);
    }
}
