using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.Extensions;
using SecurityDoors.PresentationLayer.Services.Interfaces;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Implementation
{
    /// <summary>
    /// Сервис для работы с контроллером.
    /// </summary>
	public class DoorPassingService : IDoorPassingService
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

        /// <inheritdoc/>
		public async Task<List<DoorPassingViewModel>> GetDoorPassingsAsync()
		{
			var models = dataManager.DoorsPassing.GetDoorsPassingList();
			var viewModels = new List<DoorPassingViewModel>();

			foreach (var model in models)
			{
                var cardModel = await dataManager.Cards.GetCardByIdAsync(model.CardId);
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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
