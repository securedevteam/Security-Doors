using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.PresentationLayer.Services;

namespace SecurityDoors.PresentationLayer
{
    public class ServicesManager
    {
        DataManager _dataManager;
        private CardService _cardService;

        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _cardService = new CardService(_dataManager);
        }
        public CardService Cards { get { return _cardService; } }
    }
}
