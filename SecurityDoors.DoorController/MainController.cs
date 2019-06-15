using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.DataAccessLayer.Models;

namespace SecurityDoors.DoorController
{
    /// <summary>
    /// Класс управления контроллером.
    /// </summary>
    public class MainController
    {
        private DataManager _dataManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
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
            doorpassing.Location = location;

            _dataManager.DoorsPassing.Create(doorpassing);
            _dataManager.DoorsPassing.Save(doorpassing);
        }

        /// <summary>
        /// Управление контроллером.
        /// </summary>
        /// <param name="cardNumber">уникальный номер карты.</param>
        /// <param name="doorName">название двери.</param>
        /// <returns>Строку с пояснением. Результат действия.</returns>
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

            if (door.Status != (int)DoorStatus.IsActive)
            {
                return ($" THE DOOR CLOSED(*) ", false);
            }

            if (card.Level != (int)CardStatus.IsActive)
            {
                return ($" PROBLEMS WITH CARD ", false);
            }

            if (card.Level < door.Level)
            {
                return ($" NOT ENOUGHT RIGHTS ", false);
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
