using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.Extensions;
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
                var cardModel = dataManager.Cards.GetCardById(model.CardId);
                var doorModel = dataManager.Doors.GetDoorById(model.DoorId);

                // Статус. Нахождение.
                var result = model.ConvertStatus();

                viewModels.Add(new DoorPassingViewModel()
				{
					Id = model.Id,
					Door = doorModel.Name,
					Card = cardModel.UniqueNumber,
                    Location = result.Item2,
					PassingTime = model.PassingTime,
                    Status = result.Item1,
					Comment = model.Comment
				});
			}

			return viewModels;
		}

        /// <summary>
        /// Получить проход.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Карточка.</returns>
        public DoorPassingViewModel GetDoorPassingById(int id)
        {
            var model = dataManager.DoorsPassing.GetDoorPassingById(id);

            // Статус. Нахождение.
            var result = model.ConvertStatus();

            var viewModel = new DoorPassingViewModel()
            {
                Id = model.Id,
                Location = result.Item2,
                Status = result.Item1,
                Comment = model.Comment
            };

            return viewModel;
        }

        /// <summary>
        /// Изменить проход.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Проход.</returns>
        public DoorPassingEditModel EditDoorPassingById(int id)
        {
            var model = dataManager.DoorsPassing.GetDoorPassingById(id);

            // Статус. Нахождение.
            var result = model.ConvertStatus();

            var editModel = new DoorPassingEditModel()
            {
                Id = model.Id,
                Location = result.Item2,
                Status = result.Item1,
                Comment = model.Comment
            };

            return editModel;
        }

        /// <summary>
        /// Сохранить проход с сигнатурой DoorPassingEditModel.
        /// </summary>
        /// <param name="model">Модель карточки для сохранения.</param>
        /// <returns>Карточка.</returns>
        public DoorPassingViewModel SaveCard(DoorPassingEditModel model)
        {
            var doorPassing = new DoorPassing();

            if (model.Id != 0)
            {
                doorPassing = dataManager.DoorsPassing.GetDoorPassingById(model.Id);
            }

            // Статус. Нахождение.
            var result = model.ConvertStatus();

            doorPassing.Location = result.Item2;
            doorPassing.Status = result.Item1;
            doorPassing.Comment = model.Comment;

            dataManager.DoorsPassing.Save(doorPassing);

            return GetDoorPassingById(doorPassing.Id);
        }
    }
}
