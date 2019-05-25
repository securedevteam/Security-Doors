using Microsoft.AspNetCore.Mvc;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.App.Controllers
{
    public class CardController : Controller
    {
        private ServicesManager _serviceManager;

        public CardController(DataManager dataManager)
        {
            _serviceManager = new ServicesManager(dataManager);
        }

        public IActionResult Index()
        {
            var models = _serviceManager.Cards.GetCards();
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CardEditModel card)
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

        public IActionResult Details(int id)
        {
            var model = _serviceManager.Cards.GetCardById(id);
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _serviceManager.Cards.EditCardById(id);
            return View(model);
        }

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

        public IActionResult Delete(int id)
        {
            _serviceManager.Cards.DeleteCardById(id);
            return RedirectToAction("Index");
        }
    }
}