using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Interfaces
{
    interface IDoorService
    {
        /// <summary>
        /// Получить двери.
        /// </summary>
        /// <returns>Список дверей.</returns>
		Task<List<DoorViewModel>> GetDoorsAsync();

        /// <summary>
        /// Получить дверь.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Дверь.</returns>
		Task<DoorViewModel> GetDoorByIdAsync(int id);

        /// <summary>
        /// Изменить дверь.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Дверь.</returns>
		Task<DoorEditModel> EditDoorDyIdAsync(int id);

        /// <summary>
        /// Удалить дверь.
        /// </summary>
        /// <param name="id">идентификатор.</param>
		Task DeleteDoorByIdAsync(int id);

        /// <summary>
        /// Сохранить дверь с сигнатурой DoorViewModel.
        /// </summary>
        /// <param name="model">модель двери для сохранения.</param>
        /// <returns>Дверь.</returns>
		Task<DoorViewModel> SaveDoorAsync(DoorViewModel model);

        /// <summary>
        /// Сохранить дверь с сигнатурой DoorEditModel.
        /// </summary>
        /// <param name="model">модель двери для сохранения.</param>
        /// <returns>Дверь.</returns>
        Task<DoorViewModel> SaveDoorAsync(DoorEditModel model);
    }
}
