﻿using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
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

        private string ConvertStatus(Card model)
        {
            var status = string.Empty;
			
            switch (model.Status)
			{
                case (int)CardStatus.IsClosed: { status = CardConstants.IsClosed; } break;
                case (int)CardStatus.IsActive: { status = CardConstants.IsActive; } break;
                case (int)CardStatus.IsLost: { status = CardConstants.IsLost; } break;
                case (int)CardStatus.IsSuspended: { status = CardConstants.IsSuspended; } break;
            }
			
            return status;
        }

        private int ConvertStatus(CardViewModel model)
        {
			var status = 0;

			switch (model.Status)
			{
                case CardConstants.IsClosed: { status = (int)CardStatus.IsClosed; } break;
                case CardConstants.IsActive: { status = (int)CardStatus.IsActive; } break;
                case CardConstants.IsLost: { status = (int)CardStatus.IsLost; } break;
                case CardConstants.IsSuspended: { status = (int)CardStatus.IsSuspended; } break;
            }

			return status;
        }

        private int ConvertStatus(CardEditModel model)
        {
            var status = 0;

            switch (model.Status)
            {
				case CardConstants.IsClosed: { status = (int)CardStatus.IsClosed; } break;
                case CardConstants.IsActive: { status = (int)CardStatus.IsActive; } break;
				case CardConstants.IsLost: { status = (int)CardStatus.IsLost; } break;
				case CardConstants.IsSuspended: { status = (int)CardStatus.IsSuspended; } break;
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
                status = ConvertStatus(model);
                viewModels.Add(new CardViewModel
                {
                    Id = model.Id,
                    UniqueNumber = model.UniqueNumber,
                    Status = status,
                    Comment = model.Comment
                });
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

            var status = ConvertStatus(model);

            var viewModel = new CardViewModel()
            {
                Id = model.Id,
                UniqueNumber = model.UniqueNumber,
                Status = status,
                Comment = model.Comment
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

            var status = ConvertStatus(model);

            var editModel = new CardEditModel()
            {
                Id = model.Id,
                Status = status,
                Comment = model.Comment
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
        /// <param name="model">модель карточки для сохранения.</param>
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

            var status = ConvertStatus(model);

            card.UniqueNumber = model.UniqueNumber;
            card.Status = status;
            card.Comment = model.Comment;

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

            var status = ConvertStatus(model);

            card.Status = status;
            card.Comment = model.Comment;

            dataManager.Cards.Save(card);

            return GetCardById(card.Id);
        }
    }
}
