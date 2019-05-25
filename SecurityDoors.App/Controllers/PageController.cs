using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.App.Controllers
{
    public class PageController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _serviceManager;

        public PageController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(dataManager);
        }

        public IActionResult Index()
        {
            var models = _serviceManager.Cards.CardsDatabaseModelsToView();
            return View(models);

            
        }


        public async Task<IActionResult> Details(int id)
        {


            var model = _serviceManager.Cards.CardDatabaseModelToView(id);
            return View(model);

        }

        public async Task<IActionResult> Edit(int id)
        {

            CardEditModel _editModel;
            _editModel = _serviceManager.Cards.GetCardEditModel(id);
            return View(_editModel);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(CardEditModel card)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.Cards.SaveCardEditModelToDatabase(card);
                return RedirectToAction("Index");
            }
            else
            {
                return View(card);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {


            _serviceManager.Cards.DeleteCardDatabaseModel(id);
            return RedirectToAction("Index");

        }

        //public IActionResult CardEdit(int cardId)
        //{
        //    CardEditModel editModel;

        //    return View(CardEditModel cardEditModel);
        //}
    }
}