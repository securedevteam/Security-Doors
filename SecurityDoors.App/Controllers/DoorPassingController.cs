using Microsoft.AspNetCore.Mvc;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.App.Controllers
{
    /// <summary>
    /// Контроллер для работы с дверями.
    /// </summary>
    public class DoorPassingController : Controller
    {
		private ServicesManager _serviceManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
		public DoorPassingController(DataManager dataManager)
		{
			_serviceManager = new ServicesManager(dataManager);
		}

        /// <summary>
        /// Главная страница со списком дверных проходов.
        /// </summary>
        /// <returns>Представление со списком дверных проходов.</returns>
		public ActionResult Index()
        {
            var models = _serviceManager.DoorPassing.GetDoorPassings();
            return View(models);
        }

        /// <summary>
        /// Изменение существующей карточки.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
        public IActionResult Edit(int id)
        {
            var model = _serviceManager.DoorPassing.EditDoorPassingById(id);
            return View(model);
        }

        /// <summary>
        /// Изменение существующего прохода (POST).
        /// </summary>
        /// <param name="doorPassing">модель прохода.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        public IActionResult Edit(DoorPassingEditModel doorPassing)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.DoorPassing.SaveCard(doorPassing);
                return RedirectToAction("Index");
            }
            else
            {
                return View(doorPassing);
            }
        }
    }
}