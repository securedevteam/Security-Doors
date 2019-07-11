using SecurityDoors.BusinessLogicLayer.Interfaces;

namespace SecurityDoors.BusinessLogicLayer
{
    /// <summary>
    /// Менеджер управления BLL.
    /// </summary>
    public class DataManager
    {
        private readonly ICardRepository _cardRepository;
        private readonly IDoorPassingRepository _doorPassingRepository;
        private readonly IDoorRepository _doorRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="cardRepository">репозиторий Card.</param>
        /// <param name="doorPassingRepository">репозиторий DoorPassing.</param>
        /// <param name="doorRepository">репозиторий Door.</param>
        /// <param name="personRepository">репозиторий Person.</param>
        public DataManager(ICardRepository cardRepository, IDoorPassingRepository doorPassingRepository, IDoorRepository doorRepository, IPersonRepository personRepository, IUserRepository userRepository)
        {
            _cardRepository = cardRepository;
            _doorPassingRepository = doorPassingRepository;
            _doorRepository = doorRepository;
            _personRepository = personRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Использование репозитория Card.
        /// </summary>
        public ICardRepository Cards { get { return _cardRepository; } }

        /// <summary>
        /// Использование репозитория DoorPassing.
        /// </summary>
        public IDoorPassingRepository DoorsPassing { get { return _doorPassingRepository; } }

        /// <summary>
        /// Использование репозитория Door.
        /// </summary>
        public IDoorRepository Doors { get { return _doorRepository; } }

        /// <summary>
        /// Использование репозитория Person.
        /// </summary>
        public IPersonRepository People { get { return _personRepository; } }

        /// <summary>
        /// Использование репозитория Person.
        /// </summary>
        public IUserRepository Users { get { return _userRepository; } }
    }
}
