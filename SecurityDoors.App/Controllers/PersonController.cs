using Microsoft.AspNetCore.Mvc;
using SecurityDoors.BusinessLogicLayer;
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

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
		public PersonController(DataManager dataManager)
		{
			_serviceManager = new ServicesManager(dataManager);
		}

        /// <summary>
        /// Главная страница со списком сотрудников.
        /// </summary>
        /// <returns>Представление</returns>
        public IActionResult Index()
		{
            var models = _serviceManager.Person.GetPeople();
            return View(models);
		}

        /// <summary>
        /// Создание нового сотрудника.
        /// </summary>
        /// <returns>Представление.</returns>
		public IActionResult Create()
		{
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
				_serviceManager.Person.SavePerson(person);
				return RedirectToAction(nameof(Index));
			}
			else
			{
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
            var model = _serviceManager.Person.GetPersonById(id);
            return View(model);
        }

        /// <summary>
        /// Изменение существующего сотрудника.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
		public IActionResult Edit (int id)
		{
			var editModel = _serviceManager.Person.EditPersonById(id);
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
				_serviceManager.Person.SavePerson(person);
				return RedirectToAction(nameof(Index));
			}
			else
			{
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
			_serviceManager.Person.DeletePersonById(id);
			return RedirectToAction(nameof(Index));
		}
	}
}