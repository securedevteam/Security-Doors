using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.RemoteControl.Builders;
using System;


namespace SecurityDoors.RemoteControl
{

    class Command
    {
        public static bool addPerson()
        {
            PersonBuilder personBuilder = new PersonBuilder();
            Console.WriteLine("Enter name");
            personBuilder.setName(Console.ReadLine());
            Console.WriteLine("Enter second name");
            personBuilder.setSecondName(Console.ReadLine());
            Console.WriteLine("Enter last name");
            personBuilder.setLastName(Console.ReadLine());
            Console.WriteLine("Enter gander\n1 - male\n2 - female");
            string input = Console.ReadLine();
            bool gender;
            if (input.Equals("1"))
            {
                //мужской пол
                personBuilder.setGender(true);
            }
            else if (input.Equals("1"))
            {
                //женский пол
                personBuilder.setGender(false);
            }
            else
            {
                Console.WriteLine("error");
                return false;
            }
            Console.WriteLine("Enter passport");
            personBuilder.setPassport(Console.ReadLine());
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
            if (card != null)
            {
                personBuilder.setCard(card);
            }
            Db.addPerson(personBuilder.build());
            return true;
        }

        internal static bool addDoor()
        {
            DoorBuilder doorBuilder = new DoorBuilder();
            Console.WriteLine("Enter name");
            doorBuilder.setName(Console.ReadLine());
            Console.WriteLine("Enter description");
            doorBuilder.setDescription(Console.ReadLine());
            Db.addDoor(doorBuilder.build());
            return true;
        }

        internal static bool addCard()
        {
            CardBuilder cardBuilder = new CardBuilder();
            Console.WriteLine("Enter GUID");
            cardBuilder.setGUID(Console.ReadLine());
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
            cardBuilder.setStatus(true);
            if (person != null)
            {
                cardBuilder.setPerson(person);
            }
            Db.addCard(cardBuilder.build());
            return true;
        }
    }
}