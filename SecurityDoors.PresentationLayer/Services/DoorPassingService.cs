using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.PresentationLayer.Services
{
	class DoorPassingService
	{
		DataManager dataManager;

		public DoorPassingService(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

		public DoorPassingViewModel DoorPassingDatabseModelToView(int doorPassingId) => new DoorPassingViewModel()
		{
			DoorPassing = dataManager.DoorsPassing.GetDoorPassingById(doorPassingId)
		};

		public DoorPassingEditModel GetDoorPassingEditModel(int doorPassingId)
		{
			var _dbModel = dataManager.DoorsPassing.GetDoorPassingById(doorPassingId);
			return (DoorPassingEditModel)_dbModel;
		}

		public DoorPassingViewModel SaveDoorPassingEditModel (DoorPassingEditModel doorPassingEditModel)
		{
			DoorPassing doorPassing;

			if (doorPassingEditModel.Id != 0)
			{
				doorPassing = dataManager.DoorsPassing.GetDoorPassingById(doorPassingEditModel.Id);
			}
			doorPassing = doorPassingEditModel;

			dataManager.DoorsPassing.Save(doorPassing);

			return DoorPassingDatabseModelToView(doorPassing.Id);
		}
	}
}
