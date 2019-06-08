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
    public class DoorController : Controller
    {
        private ServicesManager _serviceManager;
        private readonly ILogger _logger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
        public DoorController(DataManager dataManager, ILogger<DoorController> logger)
        {
            _serviceManager = new ServicesManager(dataManager);
            _logger = logger;
        }

        /// <summary>
        /// Главная страница со списком дверей.
        /// </summary>
        /// <returns>Представление со списком дверей.</returns>
        public IActionResult Index()
        {
            var models = _serviceManager.Doors.GetDoors();
            if (models == null)
            {
                _logger.LogWarning(LoggingEvents.ListItemsNotFound, "Door list unavailable");
            }
            _logger.LogInformation(LoggingEvents.ListItems, "Door list");
            return View(models);
        }

        /// <summary>
        /// Создание новой двери.
        /// </summary>
        /// <returns>Представление.</returns>
        public IActionResult Create()
        {
            if (View() == null)
            {
                _logger.LogWarning(LoggingEvents.CreateItemNotFound, "Door not created");
            }
            _logger.LogInformation(LoggingEvents.CreateItem, "Door created");
            return View();
        }

        /// <summary>
        /// Создание новой двери (POST).
        /// </summary>
        /// <param name="door">модель двери.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        public IActionResult Create(DoorViewModel door)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.Doors.SaveDoor(door);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (View(door) == null)
                {
                    _logger.LogWarning(LoggingEvents.CreateItemNotFound, "Door not created (POST)");
                }
                _logger.LogInformation(LoggingEvents.CreateItem, "Door created (POST)");
                return View(door);
            }
        }

        /// <summary>
        /// Информация о двери.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление</returns>
        public IActionResult Details(int id)
        {
            var model = _serviceManager.Doors.GetDoorById(id);
            if (model == null)
            {
                _logger.LogWarning(LoggingEvents.InformationItemNotFound, "Door information is not available");
            }
            _logger.LogInformation(LoggingEvents.InformationItem, "Door information received");
            return View(model);
        }

        /// <summary>
        /// Изменение существующей двери.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
        public IActionResult Edit(int id)
        {
            var model = _serviceManager.Doors.EditDoorDyId(id);
            if (model == null)
            {
                _logger.LogWarning(LoggingEvents.EditItemNotFound, "Door change failed");
            }
            _logger.LogWarning(LoggingEvents.EditItem, "Edit door");
            return View(model);
        }

        /// <summary>
        /// Изменение существующей двери (POST).
        /// </summary>
        /// <param name="door">модель двери.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        public IActionResult Edit(DoorEditModel door)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.Doors.SaveDoor(door);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (View(door) == null)
                {
                    _logger.LogWarning(LoggingEvents.EditItemNotFound, "Door change failed (POST)");
                }
                _logger.LogInformation(LoggingEvents.EditItem, "Edit door (POST)");
                return View(door);
            }
        }

        /// <summary>
        /// Удаление выбранной двери.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление главной страницы.</returns>
        public IActionResult Delete(int id)
        {
            _serviceManager.Doors.DeleteDoorById(id);
            if (RedirectToAction(nameof(Index)) == null)
            {
                _logger.LogWarning(LoggingEvents.DeleteItemNotFound, "Door not deleted");
            }
            _logger.LogInformation(LoggingEvents.DeleteItem, "Door deleted");
            return RedirectToAction(nameof(Index));
        }
    }
}