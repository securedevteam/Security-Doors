using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using SecurityDoors.PresentationLayer.Extensions;
using SecurityDoors.PresentationLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Implementation
{
    /// <summary>
    /// Сервис для работы с контроллером.
    /// </summary>
    public class CardService : ICardService
    {
        private DataManager dataManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием карточек.</param>
        public CardService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        /// <inheritdoc/>
        public async Task<List<CardViewModel>> GetCardsAsync()
        {
            var models = await dataManager.Cards.GetCardsListAsync();
            var viewModels = new List<CardViewModel>();

            foreach (var model in models)
            {
                // Статус. Уровень. Нахождение.
                (string, string, string) result = model.ConvertStatus();

                viewModels.Add(new CardViewModel
                {
                    Id = model.Id,
                    UniqueNumber = model.UniqueNumber,
                    Status = result.Item1,
                    Level = result.Item2,
                    Location = result.Item3,
                    Comment = model.Comment
                });
            }

            return viewModels;
        }

        /// <inheritdoc/>
        public CardViewModel GetCardById(int id)
        {
            var model = dataManager.Cards.GetCardById(id);

            // Статус. Уровень. Нахождение.
            (string, string, string) result = model.ConvertStatus();

            var viewModel = new CardViewModel()
            {
                Id = model.Id,
                UniqueNumber = model.UniqueNumber,
                Status = result.Item1,
                Level = result.Item2,
                Location = result.Item3,
                Comment = model.Comment
            };

            return viewModel;
        }

        /// <inheritdoc/>
        public CardEditModel EditCardById(int id)
        {
            var model = dataManager.Cards.GetCardById(id);

            // Статус. Уровень. Нахождение.
            (string, string, string) result = model.ConvertStatus();

            var editModel = new CardEditModel()
            {
                Id = model.Id,
                Status = result.Item1,
                Comment = model.Comment
            };

            return editModel;
        }

        /// <inheritdoc/>
        public void DeleteCardById(int id)
        {
            dataManager.Cards.Delete(id);
        }

        /// <inheritdoc/>
        public CardViewModel SaveCard(CardViewModel model)
        {
            var card = new Card();

            if (model.Id != 0)
            {
                card = dataManager.Cards.GetCardById(model.Id);
            }

            if(model.UniqueNumber == null)
            {
                model.UniqueNumber = Guid.NewGuid().ToString();
            }

            // Статус. Уровень. Нахождение.
            (int, int, bool) result = model.ConvertStatus();

            card.UniqueNumber = model.UniqueNumber;
            card.Status = result.Item1;
            card.Level = result.Item2;
            card.Location = result.Item3;
            card.Comment = model.Comment;

            dataManager.Cards.Save(card);

            return GetCardById(card.Id);
        }

        /// <inheritdoc/>
        public CardViewModel SaveCard(CardEditModel model)
        {
            var card = new Card();

            if (model.Id != 0)
            {
                card = dataManager.Cards.GetCardById(model.Id);
            }

            var status = model.ConvertStatus();

            card.Status = status;
            card.Comment = model.Comment;

            dataManager.Cards.Save(card);

            return GetCardById(card.Id);
        }
    }
}
