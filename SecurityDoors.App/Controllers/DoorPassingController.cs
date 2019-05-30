using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.PresentationLayer.Services;

namespace SecurityDoors.App.Controllers
{
    public class DoorPassingController : Controller
    {
		private DoorPassingService _serviceManager;
		public DoorPassingController(DataManager dataManager)
		{
			_serviceManager = new DoorPassingService(dataManager);
		}

		public ActionResult Index()
        {
            return View(_serviceManager.GetDoorPassings());
        }

    }
}