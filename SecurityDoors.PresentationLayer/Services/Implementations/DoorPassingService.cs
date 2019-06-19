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
			var models = await dataManager.DoorsPassing.GetDoorsPassingListAsync();
			var viewModels = new List<DoorPassingViewModel>();

			foreach (var model in models)
			{
                var cardModel = await dataManager.Cards.GetCardByIdAsync(model.CardId);
                var doorModel = await dataManager.Doors.GetDoorByIdAsync(model.DoorId);

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
        public async Task<DoorPassingViewModel> GetDoorPassingByIdAsync(int id)
        {
            var model = await dataManager.DoorsPassing.GetDoorPassingByIdAsync(id);

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
        public async Task<DoorPassingEditModel> EditDoorPassingByIdAsync(int id)
        {
            var model = await dataManager.DoorsPassing.GetDoorPassingByIdAsync(id);

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
        public async Task<DoorPassingViewModel> SaveCardAsync(DoorPassingEditModel model)
        {
            var doorPassing = new DoorPassing();

            if (model.Id != 0)
            {
                doorPassing = await dataManager.DoorsPassing.GetDoorPassingByIdAsync(model.Id);
            }

            // Статус. Нахождение.
            var result = model.ConvertStatus();

            doorPassing.Location = result.Item2;
            doorPassing.Status = result.Item1;
            doorPassing.Comment = model.Comment;

            await dataManager.DoorsPassing.SaveAsync(doorPassing);

            return await GetDoorPassingByIdAsync(doorPassing.Id);
        }
    }
}
