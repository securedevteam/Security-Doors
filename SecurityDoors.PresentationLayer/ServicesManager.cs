using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.PresentationLayer.Services;

namespace SecurityDoors.PresentationLayer
{
    /// <summary>
    /// Менеджер для управления Presentation layer.
    /// </summary>
    public class ServicesManager
    {
        DataManager _dataManager;

        private CardService _cardService;
		private DoorService _doorService;
		private PersonService _personService;
        private DoorPassingService _doorPassingService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер управления Business layer.</param>
        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _cardService = new CardService(_dataManager);
            _doorService = new DoorService(_dataManager);
			_personService = new PersonService(_dataManager);
            _doorPassingService = new DoorPassingService(_dataManager);
        }

        /// <summary>
        /// Сервис карт.
        /// </summary>
        public CardService Cards { get { return _cardService; } }

        /// <summary>
        /// Сервис дверей.
        /// </summary>
        public DoorService Doors { get { return _doorService; } }

        /// <summary>
        /// Сервис сотрудников.
        /// </summary>
		public PersonService People { get { return _personService; } }

        /// <summary>
        /// Сервис дверного контроллера.
        /// </summary>
        public DoorPassingService DoorPassing { get { return _doorPassingService; } }
    }
}
