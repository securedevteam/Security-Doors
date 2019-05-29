using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.PresentationLayer.Services
{
	class DoorService
	{
		DataManager dataManager;

		public DoorService(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

		public List<DoorViewModel> GetDoors()
		{
			var models = dataManager.Doors.GetDoorsList();
			var viewModels = new List<DoorViewModel>();

			foreach (var model in models)
			{
				viewModels.Add((DoorViewModel)model);
			}

			return viewModels;
		}

		public DoorViewModel GetDoorById(int id)
		{
			var model = dataManager.Doors.GetDoorById(id);
			var viewModel = (DoorViewModel)model;
			return viewModel;
		}

		public DoorEditModel EditDoorDyId(int id)
		{
			var model = dataManager.Doors.GetDoorById(id);
			var editModel = (DoorEditModel)model;
			return editModel;
		}

		public void DeleteDoorById(int id)
		{
			dataManager.Doors.Delete(id);
		}

		public DoorViewModel SaveDoor(DoorViewModel model)
		{
			var door = model;
			dataManager.Doors.Save(door);

			return GetDoorById(door.Id);
		}
	}
}
