using SecurityDoors.DataAccessLayer.Models;

namespace SecurityDoors.RemoteControl.Builders
{
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

        public CardBuilder setStatus(bool status)
        {
            card.Status = status;
            return this;
        }
        
        public CardBuilder setPerson(Person person)
        {
            card.Person = person;
            return this;
        }
    }
}
