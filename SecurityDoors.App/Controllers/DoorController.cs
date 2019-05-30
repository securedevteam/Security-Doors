using Microsoft.AspNetCore.Mvc;
using SecurityDoors.BusinessLogicLayer;
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

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
        public DoorController(DataManager dataManager)
        {
            _serviceManager = new ServicesManager(dataManager);
        }

        /// <summary>
        /// Главная страница со списком дверей.
        /// </summary>
        /// <returns>Представление со списком дверей.</returns>
        public IActionResult Index()
        {
            var models = _serviceManager.Doors.GetDoors();
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
        public IActionResult Create(DoorViewModel door)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.Doors.SaveDoor(door);
                return RedirectToAction(nameof(Index));
            }
            else
            {
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
            return RedirectToAction(nameof(Index));
        }
    }
}