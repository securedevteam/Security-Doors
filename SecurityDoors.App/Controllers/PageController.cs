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
            CardViewModel _viewModel;
            _viewModel = _serviceManager.Cards.CardDatabaseModelToView(1);
            return View(_viewModel);
        }

        //public IActionResult CardEdit(int cardId)
        //{
        //    CardEditModel editModel;

        //    return View(CardEditModel cardEditModel);
        //}
    }
}