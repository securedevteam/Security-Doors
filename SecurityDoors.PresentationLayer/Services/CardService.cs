using AutoMapper;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services
{
    public class CardService
    {
        private DataManager dataManager;
        private Mapper _mapper;

        public CardService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<CardViewModel> CardsDatabaseModelsToView()
        {
            var models = new CardViewModel()
            {
                Cards = dataManager.Cards.GetCardsList()
            };

            yield return models;
        }

        public CardViewModel CardDatabaseModelToView(int cardId)
        {
            var model = new CardViewModel()
            {
                Card = dataManager.Cards.GetCardById(cardId),
            };

            return model;
        }

        public CardEditModel GetCardEditModel(int cardId)
        {
            var _dbModel = dataManager.Cards.GetCardById(cardId);
            var _editModel = new CardEditModel()
            {
				///TODO: Это нормально? 
                Id = _dbModel.Id = _dbModel.Id,
                UniqueNumber = _dbModel.UniqueNumber = _dbModel.UniqueNumber,
                Status = _dbModel.Status = _dbModel.Status
            };

            return _editModel;
        }

        public void DeleteCardDatabaseModel(int cardId)
        {
            dataManager.Cards.Delete(cardId);
        }

        public CardViewModel SaveCardEditModelToDatabase(CardEditModel cardEditModel)
        {
            Card card = new Card();

            if (cardEditModel.Id != 0)
            {
                card = dataManager.Cards.GetCardById(cardEditModel.Id);
            }

            card.UniqueNumber = cardEditModel.UniqueNumber;
            card.Status = cardEditModel.Status;

            dataManager.Cards.Save(card);

            return CardDatabaseModelToView(card.Id);
        }
    }
}
