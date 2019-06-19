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
	public class DoorService : IDoorService
	{
        private DataManager dataManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием карточек.</param>
		public DoorService(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

        /// <inheritdoc/>
		public async Task<List<DoorViewModel>> GetDoorsAsync()
		{
			var models = await dataManager.Doors.GetDoorsListAsync();
			var viewModels = new List<DoorViewModel>();

            foreach (var model in models)
			{
                // Статус. Уровень.
                var result = model.ConvertStatus();

                viewModels.Add(new DoorViewModel
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Status = result.Item1,
                    Level = result.Item2,
                    Comment = model.Comment
                });
			}

			return viewModels;
		}

        /// <inheritdoc/>
		public async Task<DoorViewModel> GetDoorByIdAsync(int id)
		{
			var model = await dataManager.Doors.GetDoorByIdAsync(id);

            // Статус. Уровень.
            var result = model.ConvertStatus();

            var viewModel = new DoorViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Level = result.Item2,
                Status = result.Item1,
                Comment = model.Comment
            };

            return viewModel;
		}

        /// <inheritdoc/>
		public async Task<DoorEditModel> EditDoorDyIdAsync(int id)
		{
			var model = await dataManager.Doors.GetDoorByIdAsync(id);

            // Статус. Уровень.
            var result = model.ConvertStatus();

            var editModel = new DoorEditModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Status = result.Item1,
                Comment = model.Comment
            };

            return editModel;
		}

        /// <inheritdoc/>
		public async Task DeleteDoorByIdAsync(int id)
		{
			await dataManager.Doors.DeleteAsync(id);
		}

        /// <inheritdoc/>
		public async Task<DoorViewModel> SaveDoorAsync(DoorViewModel model)
		{
            var door = new Door();

            if (model.Id != 0)
            {
                door = await dataManager.Doors.GetDoorByIdAsync(model.Id);
            }

            // Статус. Уровень.
            var result = model.ConvertStatus();

            door.Name = model.Name;
            door.Description = model.Description;
            door.Status = result.Item1;
            door.Level = result.Item2;
            door.Comment = model.Comment;

            await dataManager.Doors.SaveAsync(door);

            return await GetDoorByIdAsync(door.Id);
        }

        /// <inheritdoc/>
        public async Task<DoorViewModel> SaveDoorAsync(DoorEditModel model)
        {
            var door = new Door();

            if (model.Id != 0)
            {
                door = await dataManager.Doors.GetDoorByIdAsync(model.Id);
            }

            var status = model.ConvertStatus();

            door.Name = model.Name;
            door.Description = model.Description;
            door.Status = status;
            door.Comment = model.Comment;

            await dataManager.Doors.SaveAsync(door);

            return await GetDoorByIdAsync(door.Id);
        }
    }
}
