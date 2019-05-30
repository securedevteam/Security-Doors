using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Services
{
    /// <summary>
    /// Сервис для работы с контроллером.
    /// </summary>
	public class DoorPassingService
	{
		private DataManager dataManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием карточек.</param>
		public DoorPassingService(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

        /// <summary>
        /// Получить все проходы.
        /// </summary>
        /// <returns>Список проходов.</returns>
		public List<DoorPassingViewModel> GetDoorPassings()
		{
			var models = dataManager.DoorsPassing.GetDoorsPassingList();
			var viewModels = new List<DoorPassingViewModel>();

			foreach (var model in models)
			{
				viewModels.Add(new DoorPassingViewModel()
				{
					Id = model.Id,
					DoorId = model.DoorId,
					PersonId = model.PersonId,
					PassingTime = model.PassingTime,
                    Status = model.Status,
					Comment = model.Comment
				});
			}

			return viewModels;
		}
	}
}
