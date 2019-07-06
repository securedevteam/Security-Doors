using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using SecurityDoors.PresentationLayer.Extensions;
using SecurityDoors.PresentationLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Implementations
{
    /// <summary>
    /// Сервис для работы с контроллером.
    /// </summary>
    public class CardService : ICardService
    {
        private readonly DataManager _dataManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием.</param>
        public CardService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        /// <inheritdoc/>
        public async Task<List<CardViewModel>> GetCardsAsync()
        {
            var models = await _dataManager.Cards.GetCardsListAsync();
            var viewModels = new List<CardViewModel>();

            foreach (var model in models)
            {
                // Статус. Уровень. Нахождение.
                var (status, level, location) = model.ConvertStatus();

                viewModels.Add(new CardViewModel
                {
                    Id = model.Id,
                    UniqueNumber = model.UniqueNumber,
                    Status = status,
                    Level = level,
                    Location = location,
                    Comment = model.Comment
                });
            }

            return viewModels;
        }

        /// <inheritdoc/>
        public async Task<CardViewModel> GetCardByIdAsync(int id)
        {
            var model = await _dataManager.Cards.GetCardByIdAsync(id);

            // Статус. Уровень. Нахождение.
            var (status, level, location) = model.ConvertStatus();

            var viewModel = new CardViewModel()
            {
                Id = model.Id,
                UniqueNumber = model.UniqueNumber,
                Status = status,
                Level = level,
                Location = location,
                Comment = model.Comment
            };

            return viewModel;
        }

        /// <inheritdoc/>
        public async Task<CardEditModel> EditCardByIdAsync(int id)
        {
            var model = await _dataManager.Cards.GetCardByIdAsync(id);

            // Статус. Уровень. Нахождение.
            var (status, _, _) = model.ConvertStatus();

            var editModel = new CardEditModel()
            {
                Id = model.Id,
                Status = status,
                Comment = model.Comment
            };

            return editModel;
        }

        /// <inheritdoc/>
        public async Task DeleteCardByIdAsync(int id)
        {
            await _dataManager.Cards.DeleteAsync(id);
        }

        /// <inheritdoc/>
        public async Task<CardViewModel> SaveCardAsync(CardViewModel model)
        {
            var card = new Card();

            if (model.Id != 0)
            {
                card = await _dataManager.Cards.GetCardByIdAsync(model.Id);
            }

            if(model.UniqueNumber == null)
            {
                model.UniqueNumber = Guid.NewGuid().ToString();
            }

            // Статус. Уровень. Нахождение.
            var (status, level, location) = model.ConvertStatus();

            card.UniqueNumber = model.UniqueNumber;
            card.Status = status;
            card.Level = level;
            card.Location = location;
            card.Comment = model.Comment;

            await _dataManager.Cards.SaveAsync(card);

            return await GetCardByIdAsync(card.Id);
        }

        /// <inheritdoc/>
        public async Task<CardViewModel> SaveCardAsync(CardEditModel model)
        {
            var card = new Card();

            if (model.Id != 0)
            {
                card = await _dataManager.Cards.GetCardByIdAsync(model.Id);
            }

            var status = model.ConvertStatus();

            card.Status = status;
            card.Comment = model.Comment;

            await _dataManager.Cards.SaveAsync(card);

            return await GetCardByIdAsync(card.Id);
        }
    }
}
