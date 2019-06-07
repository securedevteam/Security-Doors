using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Logger;
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
        public IActionResult Create(CardViewModel card)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.Cards.SaveCard(card);
                return RedirectToAction("Index");
            }
            else
            {
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
            _logger.LogInformation(LoggingEvents.GetItem, "Getting item {ID}", id);
            var model = _serviceManager.Cards.GetCardById(id);
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
            return RedirectToAction("Index");
        }
    }
}