using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.Extensions;
using SecurityDoors.PresentationLayer.Services.Interfaces;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Implementation
{
    /// <summary>
    /// Сервис для работы с контроллером.
    /// </summary>
	public class PersonService : IPersonService
	{
		DataManager dataManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием карточек.</param>
		public PersonService(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

        /// <inheritdoc/>
        public async Task<List<PersonViewModel>> GetPeopleAsync()
		{
			var models = dataManager.People.GetPeopleList();
			var viewModels = new List<PersonViewModel>();

            var gender = string.Empty;

            foreach (var model in models)
			{
                var cardModel = await dataManager.Cards.GetCardByIdAsync(model.CardId);

                gender = model.ConvertGender();

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

        /// <inheritdoc/>
		public async Task<PersonViewModel> GetPersonByIdAsync(int id)
		{
			var model = dataManager.People.GetPersonById(id);
            var cardModel = await dataManager.Cards.GetCardByIdAsync(model.CardId);

            var gender = model.ConvertGender();

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

        /// <inheritdoc/>
		public async Task<PersonEditModel> EditPersonByIdAsync(int id)
		{
			var model = dataManager.People.GetPersonById(id);
            var cardModel = await dataManager.Cards.GetCardByIdAsync(model.CardId);

            var gender = model.ConvertGender();

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

        /// <inheritdoc/>
		public void DeletePersonById(int id)
		{
			dataManager.People.Delete(id);
		}

        /// <inheritdoc/>
		public async Task<PersonViewModel> SavePersonAsync(PersonEditModel model)
		{
            var cardModel = await dataManager.Cards.GetCardByUniqueNumberAsync(model.Card);

            var gender = model.ConvertGender();

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

			return await GetPersonByIdAsync(person.Id);
		}

        /// <inheritdoc/>
		public async Task<PersonViewModel> SavePersonAsync(PersonViewModel model)
		{
            var cardModel = await dataManager.Cards.GetCardByUniqueNumberAsync(model.Card);

            var gender = model.ConvertGender();

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

			return await GetPersonByIdAsync(person.Id);
		}
	}
}
