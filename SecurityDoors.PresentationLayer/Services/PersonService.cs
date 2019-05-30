using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Constants;
using SecurityDoors.DataAccessLayer.Enums;
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

        #region Вспомогательные методы для смены пола для ViewModel

        private string ConvertGender(Person model)
        {
            var status = string.Empty;

            switch (model.Gender)
            {
                case (int)PersonGender.IsMale: { status = Constants.IsMale; } break;
                case (int)PersonGender.IsFemale: { status = Constants.IsFemale; } break;
            }

            return status;
        }

        private int ConvertGender(PersonViewModel model)
        {
            var status = 0;

            switch (model.Gender)
            {
                case Constants.IsMale: { status = (int)PersonGender.IsMale; } break;
                case Constants.IsFemale: { status = (int)PersonGender.IsFemale; } break;
            }

            return status;
        }

        private int ConvertGender(PersonEditModel model)
        {
            var status = 0;

            switch (model.Gender)
            {
                case Constants.IsMale: { status = (int)PersonGender.IsMale; } break;
                case Constants.IsFemale: { status = (int)PersonGender.IsFemale; } break;
            }

            return status;
        }

        #endregion

        public List<PersonViewModel> GetPeople()
		{
			var models = dataManager.People.GetPeopleList();
			var viewModels = new List<PersonViewModel>();

            var gender = string.Empty;

            foreach (var model in models)
			{
                var cardModel = dataManager.Cards.GetCardById(model.CardId);

                gender = ConvertGender(model);

                viewModels.Add(new PersonViewModel()
				{
					Id = model.Id,
					FirstName = model.FirstName,
					SecondName = model.SecondName,
					LastName = model.LastName,
					Gender = gender,
					Passport = model.Passport,
					Comment = model.Comment,
					Card = cardModel.UniqueNumber
                });
			}
			return viewModels;
		}

		public PersonViewModel GetPersonById(int id)
		{
			var model = dataManager.People.GetPersonById(id);
            var cardModel = dataManager.Cards.GetCardById(model.CardId);

            var gender = ConvertGender(model);

            return new PersonViewModel()
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				LastName = model.LastName,
				Gender = gender,
				Passport = model.Passport,
				Comment = model.Comment,
				Card = cardModel.UniqueNumber
            };
		}

		public PersonEditModel EditPersonById(int id)
		{
			var model = dataManager.People.GetPersonById(id);
            var cardModel = dataManager.Cards.GetCardById(model.CardId);

            var gender = ConvertGender(model);

            return new PersonEditModel()
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				LastName = model.LastName,
				Gender = gender,
				Passport = model.Passport,
				Comment = model.Comment,
				Card = cardModel.UniqueNumber
            };
		}

		public void DeletePersonById(int id)
		{
			dataManager.People.Delete(id);
		}

		public PersonViewModel SavePerson(PersonEditModel model)
		{
            var cardModel = dataManager.Cards.GetCardByUniqueNumber(model.Card);

            var gender = ConvertGender(model);

            var person = new Person()
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				LastName = model.LastName,
				Gender = gender,
				Passport = model.Passport,
				Comment = model.Comment,
				CardId = cardModel.Id
            };

			dataManager.People.Save(person);

			return GetPersonById(person.Id);
		}

		public PersonViewModel SavePerson(PersonViewModel model)
		{
            var cardModel = dataManager.Cards.GetCardByUniqueNumber(model.Card);

            var gender = ConvertGender(model);

            var person = new Person()
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				LastName = model.LastName,
				Gender = gender,
				Passport = model.Passport,
				Comment = model.Comment,
				CardId = cardModel.Id
            };

			dataManager.People.Save(person);

			return GetPersonById(person.Id);
		}
	}
}
