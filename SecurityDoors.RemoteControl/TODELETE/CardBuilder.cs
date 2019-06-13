﻿using SecurityDoors.Core.Enums;
using SecurityDoors.DataAccessLayer.Models;

namespace SecurityDoors.RemoteControl.Builders
{
    // TODO: ЗАЧЕМ ВООБЩЕ ЭТО? Кандидат на удаление.

    class CardBuilder
    {
        private Card card;

        public CardBuilder()
        {
            card = new Card();
        }

        public Card build()
        {
            return card;
        }

        public CardBuilder setGUID(string guid)
        {
            card.UniqueNumber = guid;
            return this;
        }

        public CardBuilder setStatus(CardStatus status)
        {
            card.Status = (int)status;
            return this;
        }
        
        public CardBuilder setPerson(Person person)
        {
            card.Person = person;
            return this;
        }
    }
}