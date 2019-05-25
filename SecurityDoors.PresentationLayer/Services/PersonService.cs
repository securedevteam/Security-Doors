using SecurityDoors.BusinessLogicLayer;
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
		public PersonViewModel PersonDatabaseModelToView(int personId) => new PersonViewModel()
		{
			Person = dataManager.People.GetPersonById(personId)
		};
		public PersonEditModel GetPersonEditModel(int personId)
		{
			var _dbModel = dataManager.People.GetPersonById(personId);
			/*
			var _editModel = new PersonEditModel()
			{
				Id = _dbModel.Id,
				FirstName = _dbModel.FirstName,
				SecondName = _dbModel.SecondName,
				LastName = _dbModel.LastName,
				Passport = _dbModel.Passport,
				Gender = _dbModel.Gender,
				CardId = _dbModel.CardId
			};

			return _editModel;*/
			return (PersonEditModel)_dbModel;
		}
		public PersonViewModel SavePersonEditModel (PersonEditModel personEditModel)
		{
			Person person;

			///TODO: а зачем этот код вообще нужен? 
			if (personEditModel.Id != 0)
			{
				person = dataManager.People.GetPersonById(personEditModel.Id);
			}

			person = personEditModel;
			
			dataManager.People.Save(person);

			return PersonDatabaseModelToView(person.Id);
		}
	}
}
