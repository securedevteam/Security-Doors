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

        private void ChangeAndSaveData(Card card, Door door, bool location)
        {
            _dataManager.Cards.Update(card);
            _dataManager.Cards.Save(card);


            var doorpassing = new DoorPassing();
            doorpassing.DoorId = door.Id;
            doorpassing.CardId = card.Id;
            doorpassing.Status = 1;
            doorpassing.Location = location; // CardConstants.IsExit;

            _dataManager.DoorsPassing.Create(doorpassing);
            _dataManager.DoorsPassing.Save(doorpassing);
        }

        public (string, bool) ControllerАctuation(string cardNumber, string doorName)
        {
            var card = _dataManager.Cards.GetCardByUniqueNumber(cardNumber);
            var door = _dataManager.Doors.GetDoorByName(doorName);

            if(card == null)
            {
                return ($" THE CARD NOT FOUND ", false);
            }

            if (door == null)
            {
                return ($" THE DOOR NOT FOUND ", false);
            }

            if (card.Location)
            {
                card.Location = false;
                ChangeAndSaveData(card, door, CardConstants.IsExit);

                return ($" SUCCESSFULLY EXIT ", true);
            }
            else
            {
                card.Location = true;
                ChangeAndSaveData(card, door, CardConstants.IsEntrance);

                return ($" SUCCESSFULLY ENTRANCE ", true);
            }
        }
    }
}
