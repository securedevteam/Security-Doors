using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Logger;
using SecurityDoors.Core.Logger.Interfaces;
using SecurityDoors.Core.Logger.Model;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.ViewModels;

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
        public IActionResult Index()
        {
            var models = _serviceManager.Cards.GetCards();
            if (models == null)
            {
                _logger.LogWarning(LoggingEvents.ListItemsNotFound, "Card list unavailable");
            }

            return View(models);
        }

        /// <summary>
        /// Создание новой карточки.
        /// </summary>
        /// <returns>Представление.</returns>
        public IActionResult Create()
        {  
            if(View() == null)
            {                
                _logger.LogWarning(LoggingEvents.CreateItemNotFound, "Card not created");
            }

            return View();

        }

        /// <summary>
        /// Создание новой карточки (POST).
        /// </summary>
        /// <param name="card">модель карточки.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        public IActionResult Create(CardViewModel card)
        {           
            if (ModelState.IsValid)
            {
                _serviceManager.Cards.SaveCard(card);
                return RedirectToAction("Index");
            }
            else
            {
                if (View(card) == null)
                {
                    _logger.LogWarning(LoggingEvents.CreateItemNotFound, "Card not created (POST)");
                }

                return View(card);
            }
        }

        /// <summary>
        /// Информация о карточке.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {            
            var model = _serviceManager.Cards.GetCardById(id);
            if (model == null)
            {
                _logger.LogWarning(LoggingEvents.InformationItemNotFound, "Сard information is not available");
            }

            return View(model);
        }

        /// <summary>
        /// Изменение существующей карточки.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
        public IActionResult Edit(int id)
        {
            var model = _serviceManager.Cards.EditCardById(id);
            if(model == null)
            {
                _logger.LogWarning(LoggingEvents.EditItemNotFound, "Сard change failed");
            }

            return View(model);
        }

        /// <summary>
        /// Изменение существующей карточки (POST).
        /// </summary>
        /// <param name="card">модель карточки.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        public IActionResult Edit(CardEditModel card)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.Cards.SaveCard(card);
                return RedirectToAction("Index");
            }
            else
            {
                if (View(card) == null)
                {
                    _logger.LogWarning(LoggingEvents.EditItemNotFound, "Сard change failed (POST)");
                }
                return View(card);
            }
        }

        /// <summary>
        /// Удаление выбранной карточки.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление главной страницы.</returns>
        public IActionResult Delete(int id)
        {            
            _serviceManager.Cards.DeleteCardById(id);
            if (RedirectToAction("Index") == null)
            {
                _logger.LogWarning(LoggingEvents.DeleteItemNotFound, "Сard not deleted");
            }
            return RedirectToAction("Index");
        }
    }
}