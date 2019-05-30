using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.PresentationLayer.Services
{
	public class DoorPassingService
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
				viewModels.Add(new DoorPassingViewModel()
				{
					Id = model.Id,
					DoorId = model.DoorId,
					PersonId = model.PersonId,
					PassingTime = model.PassingTime,
					Comment = model.Comment
				});
			}
			return viewModels;
		}
		public DoorPassingViewModel GetDoorPassingById(int id)
		{
			var model = dataManager.DoorsPassing.GetDoorPassingById(id);
			return new DoorPassingViewModel()
			{
				Id = model.Id,
				DoorId = model.DoorId,
				PersonId = model.PersonId,
				Comment = model.Comment,
				PassingTime = model.PassingTime
			};
		}

		public DoorPassingEditModel EditDoorPassingById(int id)
		{
			var model = dataManager.DoorsPassing.GetDoorPassingById(id);
			return new DoorPassingEditModel()
			{
				Id = model.Id,
				DoorId = model.DoorId,
				PersonId = model.PersonId,
				Comment = model.Comment,
				PassingTime = model.PassingTime
			};
		}

		public void DeleteDoorPassingById(int id)
		{
			dataManager.DoorsPassing.Delete(id);
		}

		public DoorPassingViewModel SaveDoorPassing(DoorPassingViewModel model)
		{
			var doorPassing = new DoorPassing()
			{
				Id = model.Id,
				DoorId = model.DoorId,
				PersonId = model.PersonId,
				Comment = model.Comment,
				PassingTime = model.PassingTime
			};
			dataManager.DoorsPassing.Save(doorPassing);
			return GetDoorPassingById(doorPassing.Id);
		}
	}
}
