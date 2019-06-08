using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Logger;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.App.Controllers
{
    /// <summary>
    /// Контроллер для работы с сотрудниками.
    /// </summary>
	public class PersonController : Controller
	{
		private ServicesManager _serviceManager;
        private readonly ILogger _logger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
		public PersonController(DataManager dataManager, ILogger<PersonController> logger)
		{
			_serviceManager = new ServicesManager(dataManager);
            _logger = logger;
        }

        /// <summary>
        /// Главная страница со списком сотрудников.
        /// </summary>
        /// <returns>Представление</returns>
        public IActionResult Index()
		{
            var models = _serviceManager.People.GetPeople();
            if (models == null)
            {
                _logger.LogWarning(LoggingEvents.ListItemsNotFound, "Person list unavailable");
            }
            return View(models);
		}

        /// <summary>
        /// Создание нового сотрудника.
        /// </summary>
        /// <returns>Представление.</returns>
		public IActionResult Create()
		{
            if (View() == null)
            {
                _logger.LogWarning(LoggingEvents.CreateItemNotFound, "Person not created");
            }
            return View();
		}

        /// <summary>
        /// Создание нового струдника (POST).
        /// </summary>
        /// <param name="person">модель сотрудника.</param>
        /// <returns>Представление.</returns>
		[HttpPost]
		public IActionResult Create(PersonViewModel person)
		{
			if (ModelState.IsValid)
			{
				_serviceManager.People.SavePerson(person);
				return RedirectToAction(nameof(Index));
			}
			else
			{
                if (View() == null)
                {
                    _logger.LogWarning(LoggingEvents.CreateItemNotFound, "Person not created (POST)");
                }
                return View();
			}
		}

        /// <summary>
        /// Информация о сотруднике.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление</returns>
        public IActionResult Details(int id)
        {
            var model = _serviceManager.People.GetPersonById(id);
            if (model == null)
            {
                _logger.LogWarning(LoggingEvents.InformationItemNotFound, "Person information is not available");
            }
            return View(model);
        }

        /// <summary>
        /// Изменение существующего сотрудника.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
		public IActionResult Edit (int id)
		{
			var editModel = _serviceManager.People.EditPersonById(id);
            if (editModel == null)
            {
                _logger.LogWarning(LoggingEvents.EditItemNotFound, "Person change failed");
            }
            return View(editModel);
		}

        /// <summary>
        /// Изменение существующего сотрудника (POST).
        /// </summary>
        /// <param name="person">модель сотрудника.</param>
        /// <returns>Представление.</returns>
		[HttpPost]
		public IActionResult Edit (PersonEditModel person)
		{
			if (ModelState.IsValid)
			{
				_serviceManager.People.SavePerson(person);
				return RedirectToAction(nameof(Index));
			}
			else
			{
                if (person == null)
                {
                    _logger.LogWarning(LoggingEvents.EditItemNotFound, "Person change failed (POST)");
                }
                return View();
			}
		}

        /// <summary>
        /// Удаление выбранного сотрудника.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление главной страницы.</returns>
		public IActionResult Delete (int id)
		{
			_serviceManager.People.DeletePersonById(id);
            if (RedirectToAction(nameof(Index)) == null)
            {
                _logger.LogWarning(LoggingEvents.DeleteItemNotFound, "Person not deleted");
            }
            return RedirectToAction(nameof(Index));
		}
	}
}