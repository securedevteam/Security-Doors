﻿using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.PresentationLayer.Services
{
	class PersonService
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
				viewModels.Add((PersonViewModel)model);
			}
			return viewModels;
		}

		public PersonViewModel GetPersonById(int id)
		=> (PersonViewModel)dataManager.People.GetPersonById(id);

		public PersonEditModel EditPersonById(int id)
		=> (PersonEditModel)dataManager.People.GetPersonById(id);

		public void DeletePersonById(int id)
		{
			dataManager.People.Delete(id);
		}

		public PersonViewModel SavePerson(PersonViewModel model)
		{
			var person = model;
			dataManager.People.Save(person);
			return GetPersonById(person.Id);
		}
	}
}
