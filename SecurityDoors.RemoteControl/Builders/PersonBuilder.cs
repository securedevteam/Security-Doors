using SecurityDoors.DataAccessLayer.Models;

namespace SecurityDoors.RemoteControl
{
    class PersonBuilder
    {
        private Person person;
        public PersonBuilder()
        {
            person = new Person();
        }

        public Person build()
        {
            return person;
        }
        public PersonBuilder setName(string name)
        {
            person.FirstName = name;
            return this;
        }

        public PersonBuilder setSecondName(string secondName)
        {
            person.SecondName = secondName;
            return this;
        }

        public PersonBuilder setLastName(string lastName)
        {
            person.LastName = lastName;
            return this;
        }

        public PersonBuilder setGender(int gender)
        {
            person.Gender = gender;
            return this;
        }

        public PersonBuilder setPassport(string passport)
        {
            person.Passport = passport;
            return this;
        }

        public PersonBuilder setCard(Card card)
        {
            person.Card = card;
            return this;
        }
    }
}