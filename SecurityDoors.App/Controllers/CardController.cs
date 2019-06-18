using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Logger;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.ViewModels;
using System;
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
        public async Task<IActionResult> Index()
        {
            var models = await _serviceManager.Cards.GetCardsAsync();

            if (models == null)
            {
                _logger.LogWarning(LoggingEvents.ListItemsNotFound, LoggerConstants.CARDS_LIST_IS_EMPTY);
            }
            else
            {
                _logger.LogInformation(LoggingEvents.ListItems, LoggerConstants.CARDS_LIST_IS_NOT_EMPTY + models.Count + AppConstants.DOT);
            }

            return View(models);
        }

        /// <summary>
        /// Создание новой карточки.
        /// </summary>
        /// <returns>Представление.</returns>
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
        public async Task<IActionResult> Create(CardViewModel card)
        {
            card.UniqueNumber = Guid.NewGuid().ToString();

            if (ModelState.IsValid)
            {
                _logger.LogInformation(LoggingEvents.CreateItem, LoggerConstants.CARD_IS_VALID + LoggerConstants.MODEL_SUCCESSFULLY_ADDED);

                await _serviceManager.Cards.SaveCardAsync(card);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogWarning(LoggingEvents.CreateItemNotFound, LoggerConstants.CARD_IS_NOT_VALID);

                return View(card);
            }
        }

        /// <summary>
        /// Информация о карточке.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {            
            var model = await _serviceManager.Cards.GetCardByIdAsync(id);

            if (model == null)
            {
                _logger.LogWarning(LoggingEvents.InformationItemNotFound, LoggerConstants.CARD_IS_EMPTY);
            }
            else
            {
                _logger.LogInformation(LoggingEvents.InformationItem, LoggerConstants.CARD_IS_NOT_EMPTY);
            }
            
            return View(model);
        }

        /// <summary>
        /// Изменение существующей карточки.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
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
        public async Task<IActionResult> Edit(CardEditModel card)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation(LoggingEvents.CreateItem, LoggerConstants.CARD_IS_VALID + LoggerConstants.MODEL_SUCCESSFULLY_UPDATED);

                await _serviceManager.Cards.SaveCardAsync(card);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogWarning(LoggingEvents.CreateItemNotFound, LoggerConstants.CARD_IS_NOT_VALID);

                return View(card);
            }
        }

        /// <summary>
        /// Удаление выбранной карточки.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление главной страницы.</returns>
        public async Task<IActionResult> Delete(int id)
        {            
            await _serviceManager.Cards.DeleteCardByIdAsync(id);

            _logger.LogInformation(LoggingEvents.DeleteItem, LoggerConstants.CARD_IS_DELETED);

            return RedirectToAction(nameof(Index));
        }
    }
}