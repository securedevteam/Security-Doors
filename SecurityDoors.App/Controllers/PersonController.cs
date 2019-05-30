using Microsoft.AspNetCore.Mvc;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.App.Controllers
{
	public class PersonController : Controller
	{
		private ServicesManager _serviceManager;
		public PersonController(DataManager dataManager)
		{
			_serviceManager = new ServicesManager(dataManager);
		}
		/// <summary>
		/// Страница со списком пользователей
		/// </summary>
		/// <returns>Представление</returns>
		public IActionResult Index()
		{
			return View(_serviceManager.Person.GetPeople());
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(PersonViewModel person)
		{
			if (ModelState.IsValid)
			{
				_serviceManager.Person.SavePerson(person);
				return RedirectToAction(nameof(Index));
			}
			else
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult Edit (int id)
		{
			var editModel = _serviceManager.Person.EditPersonById(id);
			return View(editModel);
		}

		[HttpPost]
		public IActionResult Edit (PersonEditModel person)
		{
			if (ModelState.IsValid)
			{
				_serviceManager.Person.SavePerson(person);
				return RedirectToAction(nameof(Index));
			}
			else
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult Delete (int id)
		{
			_serviceManager.Person.DeletePersonById(id);
			return RedirectToAction(nameof(Index));
		}
	}
}