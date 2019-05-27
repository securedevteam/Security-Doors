using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Services
{
    /// <summary>
    /// Сервис для работы с контроллером.
    /// </summary>
    public class CardService
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

        #region Вспомогательные методы для смены статуса карточки для ViewModel

        private string ChangeStatus(Card model, string status)
        {
            status = string.Empty;

            switch (model.Status)
            {
                case true: { status = "Активна"; } break;
                case false: { status = "Закрыта"; } break;
            }

            return status;
        }

        private bool ChangeStatus(CardViewModel model)
        {
            var status = false;

            switch (model.Status)
            {
                case "Активна": { status = true; } break;
                case "Закрыта": { status = false; } break;
            }

            return status;
        }

        private bool ChangeStatus(CardEditModel model)
        {
            var status = false;

            switch (model.Status)
            {
                case "Активна": { status = true; } break;
                case "Закрыта": { status = false; } break;
            }

            return status;
        }

        #endregion

        /// <summary>
        /// Получить карточки.
        /// </summary>
        /// <returns>Список карточек.</returns>
        public List<CardViewModel> GetCards()
        {
            var models = dataManager.Cards.GetCardsList();
            var viewModels = new List<CardViewModel>();

            var status = string.Empty;

            foreach (var model in models)
            {
                status = ChangeStatus(model, status);
                viewModels.Add(new CardViewModel { Id = model.Id, UniqueNumber = model.UniqueNumber, Status = status });
            }

            return viewModels;
        }

        /// <summary>
        /// Получить карточку.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Карточка.</returns>
        public CardViewModel GetCardById(int id)
        {
            var model = dataManager.Cards.GetCardById(id);

            var status = string.Empty;
            // TODO: Заменить на использование модели с int.
            status = ChangeStatus(model, status);

            var viewModel = new CardViewModel()
            {
                Id = model.Id,
                UniqueNumber = model.UniqueNumber,
                Status = status
            };

            return viewModel;
        }

        /// <summary>
        /// Изменить карточку.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Карточка.</returns>
        public CardEditModel EditCardById(int id)
        {
            var model = dataManager.Cards.GetCardById(id);

            // TODO: Заменить на использование модели с int.
            var status = string.Empty;
            status = ChangeStatus(model, status);

            var editModel = new CardEditModel()
            {
                Id = model.Id,
                Status = status
            };

            return editModel;
        }

        /// <summary>
        /// Удалить карточку.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        public void DeleteCardById(int id)
        {
            dataManager.Cards.Delete(id);
        }

        /// <summary>
        /// Сохранить карточку с сигнатурой CardViewModel.
        /// </summary>
        /// <param name="model">Модель карточки для сохранения.</param>
        /// <returns>Карточка.</returns>
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

            // TODO: Заменить на использование модели с int.
            var status = ChangeStatus(model);

            card.UniqueNumber = model.UniqueNumber;
            card.Status = status;

            dataManager.Cards.Save(card);

            return GetCardById(card.Id);
        }

        /// <summary>
        /// Сохранить карточку с сигнатурой CardEditModel.
        /// </summary>
        /// <param name="model">Модель карточки для сохранения.</param>
        /// <returns>Карточка.</returns>
        public CardViewModel SaveCard(CardEditModel model)
        {
            var card = new Card();

            if (model.Id != 0)
            {
                card = dataManager.Cards.GetCardById(model.Id);
            }

            // TODO: Заменить на использование модели с int.
            var status = ChangeStatus(model);

            card.Status = status;

            dataManager.Cards.Save(card);

            return GetCardById(card.Id);
        }
    }
}
