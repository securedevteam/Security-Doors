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
		public List<DoorPassingViewModel> GetDoorPassings()
		{
			var models = dataManager.DoorsPassing.GetDoorsPassingList();
			var viewModels = new List<DoorPassingViewModel>();

			foreach (var model in models)
			{
				viewModels.Add((DoorPassingViewModel)model);
			}
			return viewModels;
		}
		public DoorPassingViewModel GetDoorPassingById(int id)
		=> (DoorPassingViewModel)dataManager.DoorsPassing.GetDoorPassingById(id);

		public DoorPassingEditModel EditDoorPassingById(int id)
				=> (DoorPassingEditModel)dataManager.DoorsPassing.GetDoorPassingById(id);

		public void DeleteDoorPassingById(int id)
		{
			dataManager.DoorsPassing.Delete(id);
		}

		public DoorPassingViewModel SaveDoorPassing(DoorPassingViewModel model)
		{
			var doorPassing = model;
			dataManager.DoorsPassing.Save(doorPassing);
			return GetDoorPassingById(doorPassing.Id);
		}
	}
}
