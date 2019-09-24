using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.Extensions;
using SecurityDoors.PresentationLayer.Services.Interfaces;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Implementations
{
    /// <summary>
    /// Сервис для работы с контроллером.
    /// </summary>
	public class DoorPassingService : IDoorPassingService
	{
		private readonly DataManager _dataManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием.</param>
		public DoorPassingService(DataManager dataManager)
		{
            _dataManager = dataManager;
		}

        /// <inheritdoc/>
		public async Task<List<DoorPassingViewModel>> GetDoorPassingsAsync()
		{
			var models = await _dataManager.DoorsPassing.GetDoorsPassingListAsync();
			var viewModels = new List<DoorPassingViewModel>();

            foreach (var model in models)
			{
                var cardModel = await _dataManager.Cards.GetCardByIdAsync(model.CardId);
                var doorModel = await _dataManager.Doors.GetDoorByIdAsync(model.DoorId);

                // Статус. Нахождение.
                var (status, location) = model.ConvertStatus();

                viewModels.Add(new DoorPassingViewModel()
				{
					Id = model.Id,
					Door = doorModel.Name,
					Card = cardModel.UniqueNumber,
                    Location = location,
					PassingTime = model.PassingTime,
                    Status = status,
					Comment = model.UserAccount
				});
			}

			return viewModels;
		}

        /// <inheritdoc/>
        public async Task<DoorPassingViewModel> GetDoorPassingByIdAsync(int id)
        {
            var model = await _dataManager.DoorsPassing.GetDoorPassingByIdAsync(id);

            // Статус. Нахождение.
            var (status, location) = model.ConvertStatus();

            var viewModel = new DoorPassingViewModel()
            {
                Id = model.Id,
                Location = location,
                Status = status,
                Comment = model.UserAccount
            };

            return viewModel;
        }

        /// <inheritdoc/>
        public async Task<DoorPassingEditModel> EditDoorPassingByIdAsync(int id)
        {
            var model = await _dataManager.DoorsPassing.GetDoorPassingByIdAsync(id);

            // Статус. Нахождение.
            var (status, location) = model.ConvertStatus();

            var editModel = new DoorPassingEditModel()
            {
                Id = model.Id,
                Location = location,
                Status = status,
                Comment = model.UserAccount
            };

            return editModel;
        }

        /// <inheritdoc/>
        public async Task<DoorPassingViewModel> SaveCardAsync(DoorPassingEditModel model)
        {
            var doorPassing = new DoorPassing();

            if (model.Id != 0)
            {
                doorPassing = await _dataManager.DoorsPassing.GetDoorPassingByIdAsync(model.Id);
            }

            // Статус. Нахождение.
            var (status, location) = model.ConvertStatus();

            doorPassing.Location = location;
            doorPassing.Status = status;
            doorPassing.UserAccount = model.Comment;

            await _dataManager.DoorsPassing.SaveAsync(doorPassing);

            return await GetDoorPassingByIdAsync(doorPassing.Id);
        }
    }
}
