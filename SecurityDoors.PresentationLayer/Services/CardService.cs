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

        private string ChangeStatus(Card model)
        {
            var status = string.Empty;
			
            switch (model.Status)
			{
				case 3: { status = "Приостановлена"; } break;
				case 2: { status = "Утеряна"; } break;
				case 1: { status = "Активна"; } break;
                case 0: { status = "Закрыта"; } break;
            }
			
            return status;
        }

        private int ChangeStatus(CardViewModel model)
        {
			var status = new Int32();

			switch (model.Status)
			{
				case "Закрыта": { status = 0; } break;
				case "Активна": { status = 1; } break;
				case "Утеряна": { status = 2; } break;
				case "Приостановлена": { status = 3; } break;
			}

			return status;
        }

        private int ChangeStatus(CardEditModel model)
        {
            var status = 0;

            switch (model.Status)
            {
				case "Закрыта": { status = 0; } break;
                case "Активна": { status = 1; } break;
				case "Утеряна": { status = 2; } break;
				case "Приостановлена": { status = 3; } break;
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
                status = ChangeStatus(model);
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
            status = ChangeStatus(model);

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
            status = ChangeStatus(model);

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
