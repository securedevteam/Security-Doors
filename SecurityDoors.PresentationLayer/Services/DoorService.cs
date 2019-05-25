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
		public DoorViewModel DoorDatabaseModelToView(int doorId)
			=> new DoorViewModel()
			{
				Door = dataManager.Doors.GetDoorById(doorId)
			};
		public DoorEditModel GetDoorEditModel(int doorId)
		{
			var _dbModel = dataManager.Doors.GetDoorById(doorId);

			return (DoorEditModel)_dbModel;
		}
		public DoorViewModel SaveDoorEditModel (DoorEditModel doorEditModel)
		{
			Door door = new Door();

			if (doorEditModel.Id != 0)
			{
				door = dataManager.Doors.GetDoorById(doorEditModel.Id);
			}

			door = doorEditModel;
			dataManager.Doors.Save(door);

			return DoorDatabaseModelToView(door.Id);
		}
	}
}
