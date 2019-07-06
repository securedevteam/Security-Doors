using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.Extensions;
using SecurityDoors.PresentationLayer.Services.Interfaces;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Implementations
{
    /// <summary>
    /// Сервис для работы с контроллером.
    /// </summary>
	public class PersonService : IPersonService
	{
        private readonly DataManager _dataManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием.</param>
		public PersonService(DataManager dataManager)
		{
            _dataManager = dataManager;
		}

        /// <inheritdoc/>
        public async Task<List<PersonViewModel>> GetPeopleAsync()
		{
			var models = await _dataManager.People.GetPeopleListAsync();
			var viewModels = new List<PersonViewModel>();

            foreach (var model in models)
			{
                var cardModel = await _dataManager.Cards.GetCardByIdAsync(model.CardId);

                viewModels.Add(new PersonViewModel()
				{
					Id = model.Id,
					FirstName = model.FirstName,
					SecondName = model.SecondName,
					LastName = model.LastName,
					Gender = model.ConvertGender(),
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
			var model = await _dataManager.People.GetPersonByIdAsync(id);
            var cardModel = await _dataManager.Cards.GetCardByIdAsync(model.CardId);

            return new PersonViewModel()
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				LastName = model.LastName,
				Gender = model.ConvertGender(),
				Passport = model.Passport,
				Comment = model.Comment,
				Card = cardModel.UniqueNumber
            };
		}

        /// <inheritdoc/>
		public async Task<PersonEditModel> EditPersonByIdAsync(int id)
		{
			var model = await _dataManager.People.GetPersonByIdAsync(id);
            var cardModel = await _dataManager.Cards.GetCardByIdAsync(model.CardId);

            return new PersonEditModel()
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				LastName = model.LastName,
				Gender = model.ConvertGender(),
				Passport = model.Passport,
				Comment = model.Comment,
				Card = cardModel.UniqueNumber
            };
		}

        /// <inheritdoc/>
		public async Task DeletePersonByIdAsync(int id)
		{
			await _dataManager.People.DeleteAsync(id);
		}

        /// <inheritdoc/>
		public async Task<PersonViewModel> SavePersonAsync(PersonEditModel model)
		{
            var cardModel = await _dataManager.Cards.GetCardByUniqueNumberAsync(model.Card);

            var person = new Person()
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				LastName = model.LastName,
				Gender = model.ConvertGender(),
				Passport = model.Passport,
				Comment = model.Comment,
				CardId = cardModel.Id
            };

			await _dataManager.People.SaveAsync(person);

			return await GetPersonByIdAsync(person.Id);
		}

        /// <inheritdoc/>
		public async Task<PersonViewModel> SavePersonAsync(PersonViewModel model)
		{
            var cardModel = await _dataManager.Cards.GetCardByUniqueNumberAsync(model.Card);

            var person = new Person()
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				LastName = model.LastName,
				Gender = model.ConvertGender(),
				Passport = model.Passport,
				Comment = model.Comment,
				CardId = cardModel.Id
            };

			await _dataManager.People.SaveAsync(person);

			return await GetPersonByIdAsync(person.Id);
		}
	}
}
