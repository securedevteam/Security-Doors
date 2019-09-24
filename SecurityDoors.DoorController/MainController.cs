using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.DataAccessLayer.Models;
using System.Threading.Tasks;

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

        private async Task ChangeAndSaveDataAsync(Card card, Door door, bool location)
        {
            _dataManager.Cards.Update(card);
            await _dataManager.Cards.SaveAsync(card);

            var doorpassing = new DoorPassing()
            {
                DoorId = door.Id,
                CardId = card.Id,
                Status = 1,
                Location = location,
                UserAccount = card.Comment
            };   

            await _dataManager.DoorsPassing.CreateAsync(doorpassing);
            await _dataManager.DoorsPassing.SaveAsync(doorpassing);
        }

        /// <summary>
        /// Управление контроллером.
        /// </summary>
        /// <param name="cardNumber">уникальный номер карты.</param>
        /// <param name="doorName">название двери.</param>
        /// <returns>Строку с пояснением. Результат действия.</returns>
        public async Task<(string, bool)> ControllerАctuationAsync(string cardNumber, string doorName)
        {
            var card = await _dataManager.Cards.GetCardByUniqueNumberAsync(cardNumber);
            var door = await _dataManager.Doors.GetDoorByNameAsync(doorName);

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

            if (card.Status != (int)CardStatus.IsActive)
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
                await ChangeAndSaveDataAsync(card, door, CardConstants.IsExit);

                return ($" SUCCESSFULLY EXIT ", true);
            }
            else
            {
                card.Location = true;
                await ChangeAndSaveDataAsync(card, door, CardConstants.IsEntrance);

                return ($" SUCCESSFULLY ENTRANCE ", true);
            }
        }
    }
}
