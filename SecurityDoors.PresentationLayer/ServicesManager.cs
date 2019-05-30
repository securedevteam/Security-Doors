using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.PresentationLayer.Services;

namespace SecurityDoors.PresentationLayer
{
    public class ServicesManager
    {
        DataManager _dataManager;

        private CardService _cardService;
		private DoorService _doorService;
		private PersonService _personService;
        private DoorPassingService _doorPassingService;

        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _cardService = new CardService(_dataManager);
            _doorService = new DoorService(_dataManager);
			_personService = new PersonService(_dataManager);
            _doorPassingService = new DoorPassingService(_dataManager);
        }

        public CardService Cards { get { return _cardService; } }

        public DoorService Doors { get { return _doorService; } }

		public PersonService Person { get { return _personService; } }

        public DoorPassingService DoorPassing { get { return _doorPassingService; } }
    }
}
