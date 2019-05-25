using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Services
{
    public class CardService
    {
        private DataManager dataManager;

        public CardService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<CardViewModel> GetCards()
        {
            var models = new CardViewModel()
            {
                Cards = dataManager.Cards.GetCardsList()
            };

            yield return models;
        }

        public CardViewModel GetCardById(int id)
        {
            var model = new CardViewModel()
            {
                Card = dataManager.Cards.GetCardById(id)
            };

            return model;
        }

        public CardEditModel EditCardById(int id)
        {
            var model = dataManager.Cards.GetCardById(id);
            var editModel = new CardEditModel()
            {
				///TODO: Это нормально? 
                Id = model.Id,
                UniqueNumber = model.UniqueNumber,
                Status = model.Status
            };

            return editModel;
        }

        public void DeleteCardById(int id)
        {
            dataManager.Cards.Delete(id);
        }

        public CardViewModel SaveCard(CardEditModel model)
        {
            var card = new Card();

            if (model.Id != 0)
            {
                card = dataManager.Cards.GetCardById(model.Id);
            }

            card.UniqueNumber = model.UniqueNumber;
            card.Status = model.Status;

            dataManager.Cards.Save(card);

            return GetCardById(card.Id);
        }
    }
}
