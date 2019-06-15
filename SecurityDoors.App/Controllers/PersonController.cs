using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Logger;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;

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
            _logger.LogInformation(LoggingEvents.ListItems, "Person list");
            return View(models);
		}

        private List<string> GetListAvailableCards(int form)
        {
            var cards = _serviceManager.Cards.GetCards();
            var people = _serviceManager.People.GetPeople();

            var allUniqueNumbersCards = new List<string>();
            var getAvailableCards = new List<string>();

            foreach (var item in cards)
            {
                allUniqueNumbersCards.Add(item.UniqueNumber);
            }

            foreach (var p in people)
            {
                foreach (var c in cards)
                {
                    if (p.Card == c.UniqueNumber)
                    {
                        getAvailableCards.Add(c.UniqueNumber);
                    }
                }
            }

            var availableCards = allUniqueNumbersCards.Except(getAvailableCards).ToList();
            var listSendCardsToViewModel = new List<string>();

            if(form == 0)
            {
                listSendCardsToViewModel.Add("Не выбрано");
            }

            listSendCardsToViewModel.AddRange(availableCards);

            if(form == 1)
            {
                if (listSendCardsToViewModel.Count == 0)
                {
                    listSendCardsToViewModel.Add("Нет доступных карт");
                }
            }
            else
            {
                if (listSendCardsToViewModel.Count == 1)
                {
                    listSendCardsToViewModel.Add("Нет доступных карт");
                }
            }

            return listSendCardsToViewModel;
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
            _logger.LogInformation(LoggingEvents.CreateItem, "Person created");

            var availableCards = GetListAvailableCards(1);
            var viewModel = new PersonViewModel { AvailableCards = availableCards };
            return View(viewModel);
		}

        /// <summary>
        /// Создание нового струдника (POST).
        /// </summary>
        /// <param name="person">модель сотрудника.</param>
        /// <returns>Представление.</returns>
		[HttpPost]
		public IActionResult Create(PersonViewModel person)
		{
            if (person.Card != null &&
                person.Card != "Нет доступных карт")
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
                    _logger.LogInformation(LoggingEvents.CreateItem, "Person created (POST)");

                    return View();
                }
            }
            else
            {
                var availableCards = GetListAvailableCards(1);
                var viewModel = new PersonViewModel { AvailableCards = availableCards };
                return View(viewModel);
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
            _logger.LogInformation(LoggingEvents.InformationItem, "Person information");
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
            _logger.LogInformation(LoggingEvents.EditItem, "Edit person");

            editModel.AvailableCards = GetListAvailableCards(0);
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
            if (person.SelectedNewUniqueNumberCard != null && 
                person.SelectedNewUniqueNumberCard != "Нет доступных карт" &&
                person.SelectedNewUniqueNumberCard != "Не выбрано")
            {
                person.Card = person.SelectedNewUniqueNumberCard;
            }

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
                _logger.LogInformation(LoggingEvents.EditItem, "Edit person (POST)");

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
            _logger.LogInformation(LoggingEvents.DeleteItem, "Person deleted");
            return RedirectToAction(nameof(Index));
		}
	}
}