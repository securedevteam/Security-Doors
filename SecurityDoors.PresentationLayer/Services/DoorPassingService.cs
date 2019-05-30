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
                var personModel = dataManager.People.GetPersonById(model.PersonId);
                var doorModel = dataManager.Doors.GetDoorById(model.DoorId);

                viewModels.Add(new DoorPassingViewModel()
				{
					Id = model.Id,
					Door = doorModel.Name,
					Person = $"{personModel.FirstName} {personModel.LastName} {personModel.SecondName}",
					PassingTime = model.PassingTime,
                    Status = model.Status,
					Comment = model.Comment
				});
			}

			return viewModels;
		}
	}
}
