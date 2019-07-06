﻿using SecurityDoors.BusinessLogicLayer;
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
	public class DoorService : IDoorService
	{
        private readonly DataManager _dataManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием.</param>
		public DoorService(DataManager dataManager)
		{
            _dataManager = dataManager;
		}

        /// <inheritdoc/>
		public async Task<List<DoorViewModel>> GetDoorsAsync()
		{
			var models = await _dataManager.Doors.GetDoorsListAsync();
			var viewModels = new List<DoorViewModel>();

            foreach (var model in models)
			{
                // Статус. Уровень.
                var (status, level) = model.ConvertStatus();

                viewModels.Add(new DoorViewModel
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Status = status,
                    Level = level,
                    Comment = model.Comment
                });
			}

			return viewModels;
		}

        /// <inheritdoc/>
		public async Task<DoorViewModel> GetDoorByIdAsync(int id)
		{
			var model = await _dataManager.Doors.GetDoorByIdAsync(id);

            // Статус. Уровень.
            var (status, level) = model.ConvertStatus();

            var viewModel = new DoorViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Level = level,
                Status = status,
                Comment = model.Comment
            };

            return viewModel;
		}

        /// <inheritdoc/>
		public async Task<DoorEditModel> EditDoorDyIdAsync(int id)
		{
			var model = await _dataManager.Doors.GetDoorByIdAsync(id);

            // Статус. Уровень.
            var (status, _) = model.ConvertStatus();

            var editModel = new DoorEditModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Status = status,
                Comment = model.Comment
            };

            return editModel;
		}

        /// <inheritdoc/>
		public async Task DeleteDoorByIdAsync(int id)
		{
			await _dataManager.Doors.DeleteAsync(id);
		}

        /// <inheritdoc/>
		public async Task<DoorViewModel> SaveDoorAsync(DoorViewModel model)
		{
            var door = new Door();

            if (model.Id != 0)
            {
                door = await _dataManager.Doors.GetDoorByIdAsync(model.Id);
            }

            // Статус. Уровень.
            var (status, level) = model.ConvertStatus();

            door.Name = model.Name;
            door.Description = model.Description;
            door.Status = status;
            door.Level = level;
            door.Comment = model.Comment;

            await _dataManager.Doors.SaveAsync(door);

            return await GetDoorByIdAsync(door.Id);
        }

        /// <inheritdoc/>
        public async Task<DoorViewModel> SaveDoorAsync(DoorEditModel model)
        {
            var door = new Door();

            if (model.Id != 0)
            {
                door = await _dataManager.Doors.GetDoorByIdAsync(model.Id);
            }

            var status = model.ConvertStatus();

            door.Name = model.Name;
            door.Description = model.Description;
            door.Status = status;
            door.Comment = model.Comment;

            await _dataManager.Doors.SaveAsync(door);

            return await GetDoorByIdAsync(door.Id);
        }
    }
}
