using SecurityDoors.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer
{
    /// <summary>
    /// Менеджер управления BLL.
    /// </summary>
    public class DataManager
    {
        private ICardRepository _cardRepository;
        private IDoorPassingRepository _doorPassingRepository;
        private IDoorRepository _doorRepository;
        private IPersonRepository _personRepository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="cardRepository">репозиторий Card.</param>
        /// <param name="doorPassingRepository">репозиторий DoorPassing.</param>
        /// <param name="doorRepository">репозиторий Door.</param>
        /// <param name="personRepository">репозиторий Person.</param>
        public DataManager(ICardRepository cardRepository, IDoorPassingRepository doorPassingRepository, IDoorRepository doorRepository, IPersonRepository personRepository)
        {
            _cardRepository = cardRepository;
            _doorPassingRepository = doorPassingRepository;
            _doorRepository = doorRepository;
            _personRepository = personRepository;
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
    }
}
