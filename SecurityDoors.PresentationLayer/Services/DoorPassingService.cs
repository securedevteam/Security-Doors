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

                var status = model.Status.ConvertStatus();

                viewModels.Add(new DoorPassingViewModel()
				{
					Id = model.Id,
					Door = doorModel.Name,
					Card = cardModel.UniqueNumber,
					PassingTime = model.PassingTime,
                    Status = status,
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

            var status = model.ConvertStatus();

            var viewModel = new DoorPassingViewModel()
            {
                Id = model.Id,
                Status = status,
                Comment = model.Comment
            };

            return viewModel;
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

            var status = model.ConvertStatus();

            doorPassing.Status = status;
            doorPassing.Comment = model.Comment;

            dataManager.DoorsPassing.Save(doorPassing);

            return GetDoorPassingById(doorPassing.Id);
        }
    }
}
