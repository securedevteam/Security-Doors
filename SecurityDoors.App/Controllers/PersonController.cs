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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Index(int page = 1)
		{
            var models = await _serviceManager.People.GetPeopleAsync();

            if (models == null || models.Count == 0)
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.ListItemsNotFound, PersonLoggerConstants.PEOPLE_LIST_IS_EMPTY);
            }
            else
            {
                _logger.LogInformation(CommonSuccessfulEvents.ListItems, PersonLoggerConstants.PEOPLE_LIST_IS_NOT_EMPTY + models.Count + AppConstants.DOT);
            }

            int pageSize = 5;
            var count = models.Count;
            var items = models.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var availableCards = await GetListAvailableCardsAsync(1);

            var pageViewModel = new PageViewModel(count, page, pageSize);
            var viewModel = new PersonIndexViewModel
            {
                PageViewModel = pageViewModel,
                People = items,
                AvailableCards = availableCards
            };

            return View(viewModel);
		}

        private async Task<List<string>> GetListAvailableCardsAsync(int form)
        {
            var cards = await _serviceManager.Cards.GetCardsAsync();
            var people = await _serviceManager.People.GetPeopleAsync();

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
                listSendCardsToViewModel.Add(AppConstants.NOT_SELECTED);
            }

            listSendCardsToViewModel.AddRange(availableCards);

            if(form == 1)
            {
                if (listSendCardsToViewModel.Count == 0)
                {
                    listSendCardsToViewModel.Add(AppConstants.NO_AVAILABLE_CARDS);
                }
            }
            else
            {
                if (listSendCardsToViewModel.Count == 1)
                {
                    listSendCardsToViewModel.Add(AppConstants.NO_AVAILABLE_CARDS);
                }
            }

            return listSendCardsToViewModel;
        }

        /// <summary>
        /// Создание нового сотрудника.
        /// </summary>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Create()
		{
            var availableCards = await GetListAvailableCardsAsync(1);
            var viewModel = new PersonViewModel { AvailableCards = availableCards };

            return View(viewModel);
		}

        /// <summary>
        /// Создание нового струдника (POST).
        /// </summary>
        /// <param name="person">модель сотрудника.</param>
        /// <returns>Представление.</returns>
		[HttpPost]
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Create(PersonViewModel person)
		{
            if (person.Card != null &&
                person.Card != AppConstants.NO_AVAILABLE_CARDS)
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation(CommonSuccessfulEvents.CreateItem, PersonLoggerConstants.PERSON_IS_VALID + CommonLoggerConstants.MODEL_SUCCESSFULLY_ADDED);

                    await _serviceManager.People.SavePersonAsync(person);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogWarning(CommonUnsuccessfulEvents.CreateItemNotFound, PersonLoggerConstants.PERSON_IS_NOT_VALID);

                    return View();
                }
            }
            else
            {
                var availableCards = await GetListAvailableCardsAsync(1);
                var viewModel = new PersonViewModel { AvailableCards = availableCards };
                return View(viewModel);
            }
		}

        /// <summary>
        /// Информация о сотруднике.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление</returns>
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _serviceManager.People.GetPersonByIdAsync(id);

            if (model == null)
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.InformationItemNotFound, PersonLoggerConstants.PERSON_IS_EMPTY);
            }
            else
            {
                _logger.LogInformation(CommonSuccessfulEvents.InformationItem, PersonLoggerConstants.PERSON_IS_NOT_EMPTY);
            }

            return View(model);
        }

        /// <summary>
        /// Изменение существующего сотрудника.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Edit (int id)
		{
			var editModel = await _serviceManager.People.EditPersonByIdAsync(id);

            editModel.AvailableCards = await GetListAvailableCardsAsync(0);
            return View(editModel);
		}

        /// <summary>
        /// Изменение существующего сотрудника (POST).
        /// </summary>
        /// <param name="person">модель сотрудника.</param>
        /// <returns>Представление.</returns>
		[HttpPost]
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Edit (PersonEditModel person)
		{
            if (person.SelectedNewUniqueNumberCard != null && 
                person.SelectedNewUniqueNumberCard != AppConstants.NO_AVAILABLE_CARDS &&
                person.SelectedNewUniqueNumberCard != AppConstants.NOT_SELECTED)
            {
                person.Card = person.SelectedNewUniqueNumberCard;
            }

            if (ModelState.IsValid)
            {
                _logger.LogInformation(CommonSuccessfulEvents.EditItem, PersonLoggerConstants.PERSON_IS_VALID + CommonLoggerConstants.MODEL_SUCCESSFULLY_UPDATED);

                await _serviceManager.People.SavePersonAsync(person);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.EditItemNotFound, PersonLoggerConstants.PERSON_IS_NOT_VALID);

                return View();
            }
            
		}

        /// <summary>
        /// Удаление выбранного сотрудника.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete (int id)
		{
			await _serviceManager.People.DeletePersonByIdAsync(id);

            _logger.LogInformation(CommonSuccessfulEvents.DeleteItem, PersonLoggerConstants.PERSON_IS_DELETED);

            return RedirectToAction(nameof(Index));
		}
	}
}