using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Logger;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.App.Controllers
{
    /// <summary>
    /// Контроллер для работы с дверями.
    /// </summary>
    public class DoorPassingController : Controller
    {
		private ServicesManager _serviceManager;
        private readonly ILogger _logger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
		public DoorPassingController(DataManager dataManager, ILogger<DoorPassingController> logger)
		{
			_serviceManager = new ServicesManager(dataManager);
            _logger = logger;
        }

        /// <summary>
        /// Главная страница со списком дверных проходов.
        /// </summary>
        /// <returns>Представление со списком дверных проходов.</returns>
		public ActionResult Index()
        {
            var models = _serviceManager.DoorPassings.GetDoorPassings();
            if (models == null)
            {
                _logger.LogWarning(LoggingEvents.ListItemsNotFound, "DoorPassing list unavailable");
            }
            return View(models);
        }

        /// <summary>
        /// Изменение существующего прохода.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
        public IActionResult Edit(int id)
        {
            var model = _serviceManager.DoorPassings.EditDoorPassingById(id);
            if (model == null)
            {
                _logger.LogWarning(LoggingEvents.EditItemNotFound, "DoorPassings change failed");
            }
            return View(model);
        }

        /// <summary>
        /// Изменение существующего прохода (POST).
        /// </summary>
        /// <param name="doorPassing">модель прохода.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        public IActionResult Edit(DoorPassingEditModel doorPassing)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.DoorPassings.SaveCard(doorPassing);
                return RedirectToAction("Index");
            }
            else
            {
                if (View(doorPassing) == null)
                {
                    _logger.LogWarning(LoggingEvents.EditItemNotFound, "DoorPassing change failed (POST)");
                }
                return View(doorPassing);
            }
        }
    }
}