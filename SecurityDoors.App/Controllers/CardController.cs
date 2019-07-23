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
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityDoors.App.Controllers
{
    /// <summary>
    /// Контроллер для работы с карточками сотрудников.
    /// </summary>
    public class CardController : Controller
    {
        private ServicesManager _serviceManager;
        private readonly ILogger _logger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием карточек.</param>
        public CardController(DataManager dataManager, ILogger<CardController> logger)
        {
            _serviceManager = new ServicesManager(dataManager);
            _logger = logger;
        }

        /// <summary>
        /// Главная страница со списком карточек.
        /// </summary>
        /// <returns>Представление со списком карточек.</returns>
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var models = await _serviceManager.Cards.GetCardsAsync();

            if (models == null || models.Count == 0)
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.ListItemsNotFound, CardLoggerConstants.CARDS_LIST_IS_EMPTY);
            }
            else
            {
                _logger.LogInformation(CommonSuccessfulEvents.ListItems, CardLoggerConstants.CARDS_LIST_IS_NOT_EMPTY + models.Count + AppConstants.DOT);
            }

            int pageSize = 15;
            var count = models.Count;
            var items = models.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var pageViewModel = new PageViewModel(count, page, pageSize);
            var viewModel = new CardIndexViewModel
            {
                PageViewModel = pageViewModel,
                Cards = items
            };

            return View(viewModel);
        }

        /// <summary>
        /// Создание новой карточки.
        /// </summary>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {  
            return View();
        }

        /// <summary>
        /// Создание новой карточки (POST).
        /// </summary>
        /// <param name="card">модель карточки.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(CardViewModel card)
        {
            card.UniqueNumber = Guid.NewGuid().ToString();

            if (ModelState.IsValid)
            {
                _logger.LogInformation(CommonSuccessfulEvents.CreateItem, CardLoggerConstants.CARD_IS_VALID + CommonLoggerConstants.MODEL_SUCCESSFULLY_ADDED);

                await _serviceManager.Cards.SaveCardAsync(card);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.CreateItemNotFound, CardLoggerConstants.CARD_IS_NOT_VALID);

                return View(card);
            }
        }

        /// <summary>
        /// Информация о карточке.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Details(int id)
        {            
            var model = await _serviceManager.Cards.GetCardByIdAsync(id);

            if (model == null)
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.InformationItemNotFound, CardLoggerConstants.CARD_IS_EMPTY);
            }
            else
            {
                _logger.LogInformation(CommonSuccessfulEvents.InformationItem, CardLoggerConstants.CARD_IS_NOT_EMPTY);
            }
            
            return View(model);
        }

        /// <summary>
        /// Изменение существующей карточки.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _serviceManager.Cards.EditCardByIdAsync(id);

            return View(model);
        }

        /// <summary>
        /// Изменение существующей карточки (POST).
        /// </summary>
        /// <param name="card">модель карточки.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(CardEditModel card)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation(CommonSuccessfulEvents.EditItem, CardLoggerConstants.CARD_IS_VALID + CommonLoggerConstants.MODEL_SUCCESSFULLY_UPDATED);

                await _serviceManager.Cards.SaveCardAsync(card);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.EditItemNotFound, CardLoggerConstants.CARD_IS_NOT_VALID);

                return View(card);
            }
        }

        /// <summary>
        /// Удаление выбранной карточки.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление главной страницы.</returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {            
            await _serviceManager.Cards.DeleteCardByIdAsync(id);

            _logger.LogInformation(CommonSuccessfulEvents.DeleteItem, CardLoggerConstants.CARD_IS_DELETED);

            return RedirectToAction(nameof(Index));
        }
    }
}