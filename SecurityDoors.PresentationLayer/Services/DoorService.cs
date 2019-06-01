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
	public class DoorService
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

        /// <summary>
        /// Получить двери.
        /// </summary>
        /// <returns>Список дверей.</returns>
		public List<DoorViewModel> GetDoors()
		{
			var models = dataManager.Doors.GetDoorsList();
			var viewModels = new List<DoorViewModel>();

            var status = string.Empty;

            foreach (var model in models)
			{
                status = model.ConvertStatus();
                viewModels.Add(new DoorViewModel
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Status = status,
                    Comment = model.Comment
                });
			}

			return viewModels;
		}

        /// <summary>
        /// Получить дверь.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Дверь.</returns>
		public DoorViewModel GetDoorById(int id)
		{
			var model = dataManager.Doors.GetDoorById(id);

            var status = model.ConvertStatus();

            var viewModel = new DoorViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Status = status,
                Comment = model.Comment
            };

            return viewModel;
		}

        /// <summary>
        /// Изменить дверь.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Дверь.</returns>
		public DoorEditModel EditDoorDyId(int id)
		{
			var model = dataManager.Doors.GetDoorById(id);

            var status = model.ConvertStatus();

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

        /// <summary>
        /// Удалить дверь.
        /// </summary>
        /// <param name="id">идентификатор.</param>
		public void DeleteDoorById(int id)
		{
			dataManager.Doors.Delete(id);
		}

        /// <summary>
        /// Сохранить дверь с сигнатурой DoorViewModel.
        /// </summary>
        /// <param name="model">модель двери для сохранения.</param>
        /// <returns>Дверь.</returns>
		public DoorViewModel SaveDoor(DoorViewModel model)
		{
            var door = new Door();

            if (model.Id != 0)
            {
                door = dataManager.Doors.GetDoorById(model.Id);
            }

            var status = model.ConvertStatus();

            door.Name = model.Name;
            door.Description = model.Description;
            door.Status = status;
            door.Comment = model.Comment;

            dataManager.Doors.Save(door);

            return GetDoorById(door.Id);
        }

        /// <summary>
        /// Сохранить дверь с сигнатурой DoorEditModel.
        /// </summary>
        /// <param name="model">модель двери для сохранения.</param>
        /// <returns>Дверь.</returns>
        public DoorViewModel SaveDoor(DoorEditModel model)
        {
            var door = new Door();

            if (model.Id != 0)
            {
                door = dataManager.Doors.GetDoorById(model.Id);
            }

            var status = model.ConvertStatus();

            door.Name = model.Name;
            door.Description = model.Description;
            door.Status = status;
            door.Comment = model.Comment;

            dataManager.Doors.Save(door);

            return GetDoorById(door.Id);
        }
    }
}
