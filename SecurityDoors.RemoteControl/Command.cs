using SecurityDoors.DataAccessLayer.Models;
using System;


namespace SecurityDoors.RemoteControl
{

    class Command
    {
        public static bool addPerson()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter second name");
            string secondName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter gander\n1 - male\n2 - female");
            string input = Console.ReadLine();
            bool gender;
            if (input.Equals("1"))
            {
                //мужской пол
                gender = true;
            } else if (input.Equals("1"))
            {
                //женский пол
                gender = false;
            } else
            {
                Console.WriteLine("error");
                return false;
            }
            Console.WriteLine("Enter passport");
            string passport = Console.ReadLine();
            Console.WriteLine("want to add a card to an person\n1 - yes\n2 - no");
            input = Console.ReadLine();
            Card card = null;
            if (input.Equals("1"))
            {
                Console.WriteLine("enter id of card which you want to add\nenter q to exit");
                int id = -1;
                do
                {
                    try
                    {
                        input = Console.ReadLine();
                        if (input.Equals("q"))
                        {
                            break;
                        }
                        id = int.Parse(input);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("input don't number");
                    }
                } while (Db.FindCard(id) != null);
                card = Db.FindCard(id);
            }
            Person person = new Person();
            person.FirstName = name;
            person.LastName = lastName;
            person.SecondName = secondName;
            person.Gender = gender;
            person.Passport = passport;
            person.Card = card;
            Db.addPerson(person);
            return true;
        }

        internal static bool addDoor()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter description");
            string description = Console.ReadLine();
            Door door = new Door();
            door.Name = name;
            door.Description = description;
            Db.addDoor(door);
            return true;
        }

        internal static bool addCard()
        {
            Console.WriteLine("Enter GUID");
            string guid = Console.ReadLine();
            Console.WriteLine("want to add a person to an card\n1 - yes\n2 - no");
            string input = Console.ReadLine();
            Person person = null;
            if (input.Equals("1"))
            {
                Console.WriteLine("enter id of person which you want to add\nenter q to exit");
                int id = -1;
                do
                {
                    try
                    {
                        input = Console.ReadLine();
                        if (input.Equals("q"))
                        {
                            break;
                        }
                        id = int.Parse(input);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("input don't number");
                    }
                } while (Db.FindPerson(id) != null);
                person = Db.FindPerson(id);
            }
            Card card = new Card();
            card.UniqueNumber = guid;
            card.Status = true;
            if (person != null)
            {
                card.Person = person;
            }
            Db.addCard(card);
            return true;
        }
    }
}
