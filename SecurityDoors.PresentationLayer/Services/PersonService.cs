using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.PresentationLayer.Services
{
	public class PersonService
	{
		DataManager dataManager;

		public PersonService(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

		public List<PersonViewModel> GetPeople()
		{
			var models = dataManager.People.GetPeopleList();
			var viewModels = new List<PersonViewModel>();

			foreach (var model in models)
			{
				viewModels.Add(new PersonViewModel()
				{
					Id = model.Id,
					FirstName = model.FirstName,
					SecondName = model.SecondName,
					LastName = model.LastName,
					Gender = model.Gender,
					Passport = model.Passport,
					Comment = model.Comment,
					CardId = model.CardId
				});
			}
			return viewModels;
		}

		public PersonViewModel GetPersonById(int id)
		{
			var model = dataManager.People.GetPersonById(id);
			return new PersonViewModel()
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				LastName = model.LastName,
				Gender = model.Gender,
				Passport = model.Passport,
				Comment = model.Comment,
				CardId = model.CardId
			};
		}

		public PersonEditModel EditPersonById(int id)
		{
			var model = dataManager.People.GetPersonById(id);
			return new PersonEditModel()
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				LastName = model.LastName,
				Gender = model.Gender,
				Passport = model.Passport,
				Comment = model.Comment,
				CardId = model.CardId
			};
		}

		public void DeletePersonById(int id)
		{
			dataManager.People.Delete(id);
		}

		public PersonViewModel SavePerson(PersonEditModel model)
		{
			var person = new Person()
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				LastName = model.LastName,
				Gender = model.Gender,
				Passport = model.Passport,
				Comment = model.Comment,
				CardId = model.CardId
			};
			dataManager.People.Save(person);
			return GetPersonById(person.Id);
		}

		public PersonViewModel SavePerson(PersonViewModel model)
		{
			var person = new Person()
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				LastName = model.LastName,
				Gender = model.Gender,
				Passport = model.Passport,
				Comment = model.Comment,
				CardId = model.CardId
			};
			dataManager.People.Save(person);
			return GetPersonById(person.Id);
		}
	}
}
