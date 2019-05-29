using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.PresentationLayer.Services;

namespace SecurityDoors.PresentationLayer
{
    public class ServicesManager
    {
        DataManager _dataManager;
        private CardService _cardService;
        private DoorService _doorService;

        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _cardService = new CardService(_dataManager);
            _doorService = new DoorService(_dataManager);
        }
        public CardService Cards { get { return _cardService; } }
        public DoorService Doors { get { return _doorService; } }
    }
}
