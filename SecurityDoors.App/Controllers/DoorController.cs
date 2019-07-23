using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Logger.Constants;
using SecurityDoors.Core.Logger.Events;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.Paginations;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Linq;
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
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var models = await _serviceManager.Doors.GetDoorsAsync();

            if (models == null || models.Count == 0)
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.ListItemsNotFound, DoorLoggerConstants.DOORS_LIST_IS_EMPTY);
            }
            else
            {
                _logger.LogInformation(CommonSuccessfulEvents.ListItems, DoorLoggerConstants.DOORS_LIST_IS_NOT_EMPTY + models.Count + AppConstants.DOT);
            }

            int pageSize = 5;
            var count = models.Count;
            var items = models.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var pageViewModel = new PageViewModel(count, page, pageSize);
            var viewModel = new DoorIndexViewModel
            {
                PageViewModel = pageViewModel,
                Doors = items
            };

            return View(viewModel);
        }

        /// <summary>
        /// Создание новой двери.
        /// </summary>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin, moderator")]
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
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Create(DoorViewModel door)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation(CommonSuccessfulEvents.CreateItem, DoorLoggerConstants.DOOR_IS_VALID + CommonLoggerConstants.MODEL_SUCCESSFULLY_ADDED);

                await _serviceManager.Doors.SaveDoorAsync(door);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.CreateItemNotFound, DoorLoggerConstants.DOOR_IS_NOT_VALID);

                return View(door);
            }
        }

        /// <summary>
        /// Информация о двери.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _serviceManager.Doors.GetDoorByIdAsync(id);

            if (model == null)
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.InformationItemNotFound, DoorLoggerConstants.DOOR_IS_EMPTY);
            }
            else
            {
                _logger.LogInformation(CommonSuccessfulEvents.InformationItem, DoorLoggerConstants.DOOR_IS_NOT_EMPTY);
            }

            return View(model);
        }

        /// <summary>
        /// Изменение существующей двери.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin, moderator")]
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
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Edit(DoorEditModel door)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation(CommonSuccessfulEvents.EditItem, DoorLoggerConstants.DOOR_IS_VALID + CommonLoggerConstants.MODEL_SUCCESSFULLY_UPDATED);

                await _serviceManager.Doors.SaveDoorAsync(door);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.EditItemNotFound, DoorLoggerConstants.DOOR_IS_NOT_VALID);

                return View(door);
            }
        }

        /// <summary>
        /// Удаление выбранной двери.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceManager.Doors.DeleteDoorByIdAsync(id);

            _logger.LogInformation(CommonSuccessfulEvents.DeleteItem, DoorLoggerConstants.DOOR_IS_DELETED);

            return RedirectToAction(nameof(Index));
        }
    }
}