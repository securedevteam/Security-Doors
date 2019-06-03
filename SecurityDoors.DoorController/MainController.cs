using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Constants;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.DoorController
{
    public class MainController
    {
        private DataManager _dataManager;
        

        public MainController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void ControllerАctuation(string cardNumber, string doorName)
        {
            var card = _dataManager.Cards.GetCardByUniqueNumber(cardNumber);
            var door = _dataManager.Doors.GetDoorByName(doorName);

            if (card != null && door != null)
            {
                if(card.Location)
                {
                    card.Location = false;
                    _dataManager.Cards.Update(card);
                    _dataManager.Cards.Save(card);


                    var doorpassing = new DoorPassing();
                    doorpassing.DoorId = door.Id;
                    doorpassing.CardId = card.Id;
                    doorpassing.Status = 1;
                    doorpassing.Location = CardConstants.IsExit;

                    _dataManager.DoorsPassing.Create(doorpassing);
                    _dataManager.DoorsPassing.Save(doorpassing);
                }
                else
                {
                    card.Location = true;
                    _dataManager.Cards.Update(card);
                    _dataManager.Cards.Save(card);

                    var doorpassing = new DoorPassing();
                    doorpassing.DoorId = door.Id;
                    doorpassing.CardId = card.Id;
                    doorpassing.Status = 1;
                    doorpassing.Location = CardConstants.IsEntrance;

                    _dataManager.DoorsPassing.Create(doorpassing);
                    _dataManager.DoorsPassing.Save(doorpassing);
                }
            }
        }
    }
}
