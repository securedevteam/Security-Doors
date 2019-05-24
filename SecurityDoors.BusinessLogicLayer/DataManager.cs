using SecurityDoors.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer
{
    public class DataManager
    {
        private ICardRepository _cardRepository;
        private IDoorPassingRepository _doorPassingRepository;
        private IDoorRepository _doorRepository;
        private IPersonRepository _personRepository;

        public DataManager(ICardRepository cardRepository, IDoorPassingRepository doorPassingRepository, IDoorRepository doorRepository, IPersonRepository personRepository)
        {
            _cardRepository = cardRepository;
            _doorPassingRepository = doorPassingRepository;
            _doorRepository = doorRepository;
            _personRepository = personRepository;
        }

        public ICardRepository Cards { get { return _cardRepository; } }
        public IDoorPassingRepository DoorsPassing { get { return _doorPassingRepository; } }
        public IDoorRepository Doors { get { return _doorRepository; } }
        public IPersonRepository People { get { return _personRepository; } }
    }
}
