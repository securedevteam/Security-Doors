using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Services.Interfaces
{
    interface IDoorService
    {
        /// <summary>
        /// Получить двери.
        /// </summary>
        /// <returns>Список дверей.</returns>
		List<DoorViewModel> GetDoors();

        /// <summary>
        /// Получить дверь.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Дверь.</returns>
		DoorViewModel GetDoorById(int id);

        /// <summary>
        /// Изменить дверь.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Дверь.</returns>
		DoorEditModel EditDoorDyId(int id);

        /// <summary>
        /// Удалить дверь.
        /// </summary>
        /// <param name="id">идентификатор.</param>
		void DeleteDoorById(int id);

        /// <summary>
        /// Сохранить дверь с сигнатурой DoorViewModel.
        /// </summary>
        /// <param name="model">модель двери для сохранения.</param>
        /// <returns>Дверь.</returns>
		DoorViewModel SaveDoor(DoorViewModel model);

        /// <summary>
        /// Сохранить дверь с сигнатурой DoorEditModel.
        /// </summary>
        /// <param name="model">модель двери для сохранения.</param>
        /// <returns>Дверь.</returns>
        DoorViewModel SaveDoor(DoorEditModel model);
    }
}
