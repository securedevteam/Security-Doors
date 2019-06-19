using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Logger;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            var models = await _serviceManager.Doors.GetDoorsAsync();

            if (models == null)
            {
                _logger.LogWarning(LoggingEvents.ListItemsNotFound, LoggerConstants.DOORS_LIST_IS_EMPTY);
            }
            else
            {
                _logger.LogInformation(LoggingEvents.ListItems, LoggerConstants.DOORS_LIST_IS_NOT_EMPTY + models.Count + AppConstants.DOT);
            }

            return View(models);
        }

        /// <summary>
        /// Создание новой двери.
        /// </summary>
        /// <returns>Представление.</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Создание новой двери (POST).
        /// </summary>
        /// <param name="door">модель двери.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(DoorViewModel door)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation(LoggingEvents.CreateItem, LoggerConstants.DOOR_IS_VALID + LoggerConstants.MODEL_SUCCESSFULLY_ADDED);

                await _serviceManager.Doors.SaveDoorAsync(door);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogWarning(LoggingEvents.CreateItemNotFound, LoggerConstants.DOOR_IS_NOT_VALID);

                return View(door);
            }
        }

        /// <summary>
        /// Информация о двери.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление</returns>
        public async Task<IActionResult> Details(int id)
        {
            var model = await _serviceManager.Doors.GetDoorByIdAsync(id);

            if (model == null)
            {
                _logger.LogWarning(LoggingEvents.InformationItemNotFound, LoggerConstants.DOOR_IS_EMPTY);
            }
            else
            {
                _logger.LogInformation(LoggingEvents.InformationItem, LoggerConstants.DOOR_IS_NOT_EMPTY);
            }

            return View(model);
        }

        /// <summary>
        /// Изменение существующей двери.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _serviceManager.Doors.EditDoorDyIdAsync(id);

            return View(model);
        }

        /// <summary>
        /// Изменение существующей двери (POST).
        /// </summary>
        /// <param name="door">модель двери.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(DoorEditModel door)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation(LoggingEvents.CreateItem, LoggerConstants.DOOR_IS_VALID + LoggerConstants.MODEL_SUCCESSFULLY_UPDATED);

                await _serviceManager.Doors.SaveDoorAsync(door);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogWarning(LoggingEvents.CreateItemNotFound, LoggerConstants.DOOR_IS_NOT_VALID);

                return View(door);
            }
        }

        /// <summary>
        /// Удаление выбранной двери.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление главной страницы.</returns>
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceManager.Doors.DeleteDoorByIdAsync(id);

            _logger.LogInformation(LoggingEvents.DeleteItem, LoggerConstants.DOOR_IS_DELETED);

            return RedirectToAction(nameof(Index));
        }
    }
}