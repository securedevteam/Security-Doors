using SecurityDoors.Core.Enums;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.RemoteControl.Builders;
using SecurityDoors.RemoteControl.cli;
using System;


namespace SecurityDoors.RemoteControl
{

    class Command
    {
        private Database db = new Database();

        #region методы для добавления обьектов в БД
        /// <summary>
        /// логика для добавления Person в БД.
        /// метод запрашивает все необходимые данные после чего 
        /// добавляет в БД обьект
        /// </summary>
        public void addPerson()
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
            if (input.Equals("1"))
            {
                //мужской пол
                personBuilder.setGender(1);
            }
            else if (input.Equals("1"))
            {
                //женский пол
                personBuilder.setGender(0);
            }
            else
            {
                Color.writeError("error");
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
                } while (db.GetCardById(id) != null);
                card = db.GetCardById(id);
            }
            if (card != null)
            {
                personBuilder.setCard(card);
            }
            db.AddPerson(personBuilder.build());
            Console.WriteLine("person added succesfull");
        }

        /// <summary>
        /// логика для добавления Door в БД.
        /// метод запрашивает все необходимые данные после чего 
        /// добавляет в БД обьект
        /// </summary>
        public void addDoor()
        {
            DoorBuilder doorBuilder = new DoorBuilder();
            Console.WriteLine("Enter name");
            doorBuilder.setName(Console.ReadLine());
            Console.WriteLine("Enter description");
            doorBuilder.setDescription(Console.ReadLine());
            db.AddDoor(doorBuilder.build());
            Console.WriteLine("door added succesfull");
        }

        /// <summary>
        /// логика для добавления Card в БД.
        /// метод запрашивает все необходимые данные после чего 
        /// добавляет в БД обьект
        /// </summary>
        public void addCard()
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
                        Console.WriteLine("input doesn't number");
                    }
                } while (db.GetPersonById(id) != null);
                person = db.GetPersonById(id);
            }
			///TODO: Реализовать выбор типа статуса
            cardBuilder.setStatus((int)CardStatus.IsActive);
            if (person != null)
            {
                cardBuilder.setPerson(person);
            }
            db.AddCard(cardBuilder.build());
            Console.WriteLine("card added succesfull");
        }
        #endregion

        #region служебные методы для помощи пользователю программы
        /// <summary>
        /// метод который очищает экран консоли
        /// </summary>
        internal void clearScreen()
        {
            Console.Clear();
        }

        /// <summary>
        /// печать всех доступных для ввода команд 
        /// </summary>
        internal void printHelp()
        {
            Console.WriteLine("aviable command:   \n" +
                           "quit              || q  \n" +
                           "help              || h  \n" +
                           "clear             || c  \n" +
                           "add-person        || a-p\n" +
                           "add-door          || a-d\n" +
                           "add-card          || a-c\n" +
                           "count-record      || c-r\n" +
                           "list-person       || l-p\n" +
                           "list-card         || l-c\n" +
                           "list-door         || l-d\n" +
                           "list-doorPassing  || l-dp\n" +
                           "show-person       || s-p\n" +
                           "show-card         || s-c\n" +
                           "show-door         || s-d\n" +
                           "delete-person     || d-p\n" +
                           "delete-card       || d-c\n" +
                           "delete-door       || d-d\n" +
                           "delete-doorPassing|| d-dp");
        }

        internal void printCountOfRecord()
        {
            Console.WriteLine("DoorPassing:\t{0}", db.GetCountOfDoorPassing());
            Console.WriteLine("person:     \t{0}", db.GetCountOfPerson());
            Console.WriteLine("card:       \t{0}", db.GetCountOfCard());
            Console.WriteLine("Door:       \t{0}", db.GetCountOfDoor());
        }
        #endregion

        #region методы для печати обьектов из БД
        /// <summary>
        /// метод печатающий Door по id
        /// </summary>
        internal void printDoor()
        {
            int id = -1;
            Console.WriteLine("enter door id");
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                //TODO error message
            }
            Door door = db.GetDoorById(id);
            if (door != null)
            {
                Console.WriteLine("id\t{0}", door.Id);
                Console.WriteLine("description\t{0}", door.Description);
            }
            else
            {
                Console.WriteLine("card with given id does not exitst");
            }
        }

        /// <summary>
        /// метод печатающий Card по id
        /// </summary>
        public void printCard()
        {
            int id = -1;
            Console.WriteLine("enter card id");
            try
            {
                id = int.Parse(Console.ReadLine());
            } catch (FormatException)
            {
                //TODO error message
            }
            Card card = db.GetCardById(id);
            if (card != null)
            {
                Console.WriteLine("id:\t{0}", card.Id);
                Console.WriteLine("person:\t{0}", card.Person);
                Console.WriteLine("status:\t{0}", card.Status.ToString());
                Console.WriteLine("GUID:\t{0}", card.UniqueNumber);
            } else
            {
                Console.WriteLine("card with given id does not exitst");
            }
        }

        /// <summary>
        /// метод печатающий Person по id
        /// </summary>
        public void printPerson()
        {
            int id = -1;
            Console.WriteLine("enter person id");
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                //TODO error message
            }
            Person person = db.GetPersonById(id);
            if (person != null)
            {
                Console.WriteLine("id:\t{0}", person.Id);
                Console.WriteLine("name:\t{0}", person.FirstName);
                Console.WriteLine("second name:\t{0}", person.SecondName);
                Console.WriteLine("last name:\t{0}", person.LastName);
                if (person.Gender == 1)
                {
                    Console.WriteLine("gender\tmale");
                }
                else
                {
                    Console.WriteLine("gender:\tfemale");
                }
                Console.WriteLine("passport:\t{0}", person.Passport);
            } else
            {
                Console.WriteLine("person with given id does not exitst");
            }
        }
        #endregion

        #region методы для печати списка обьектов из БД
        /// <summary>
        /// печать основных полей всех обьектов DoorPassing в БД:
        /// id
        /// time
        /// </summary>
        public void printListOfDoorPassing()
        {
            Console.Write("id");
            Console.Write("\t");
            Console.WriteLine("time");
            foreach (DoorPassing doorPassing in db.GetDoorPassings())
            {
                Console.Write(doorPassing.Id);
                Console.Write("\t");
                Console.WriteLine(doorPassing.PassingTime);
            }
        }

        /// <summary>
        /// печать основных полей всех обьектов Card в БД:
        /// id
        /// GUID
        /// </summary>
        public void printListOfCard()
        {
            Console.Write("id");
            Console.Write("\t");
            Console.WriteLine("GUID");
            foreach (Card card in db.GetCards())
            {
                Console.Write(card.Id);
                Console.Write("\t");
                Console.WriteLine(card.UniqueNumber);
            }
        }

        /// <summary>
        /// печать основных полей всех обьектов Person в БД:
        /// id
        /// name
        /// second name
        /// last name
        /// </summary>
        public void printListOfPerson()
        {
            Console.Write("id");
            Console.Write("\t");
            Console.WriteLine("name\tsecond name\tlast name");
            foreach (Person person in db.GetPersons())
            {
                Console.Write(person.Id);
                Console.Write("\t");
                Console.WriteLine("{0}\t{1}\t{2}", person.FirstName, person.SecondName, person.LastName);
            }
        }

        /// <summary>
        /// печать основных полей всех обьектов Door в БД:
        /// id
        /// description
        /// </summary>
        public void printListOfDoor()
        {
            Console.Write("id");
            Console.Write("\t");
            Console.WriteLine("description");
            foreach (Door door in db.GetDoors())
            {
                Console.Write(door.Id);
                Console.Write("\t");
                Console.WriteLine(door.Description);
            }
        }
        #endregion

        #region методы для удаления обьектов из БД
        /// <summary>
        /// удаление обьекта Person из БД по его id
        /// </summary>
        public void DeletePerson()
        {
            Console.WriteLine("enter person id");
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }catch (FormatException)
            {
                Color.writeError("input does not number");
            }
            db.deletePerson(id);
        }

        /// <summary>
        /// удаление обьекта Card из БД по его id
        /// </summary>
        public void DeleteCard()
        {
            Console.WriteLine("enter card id");
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Color.writeError("input does not number");
            }
            db.deleteCard(id);
        }

        /// <summary>
        /// удаление обьекта Door из БД по его id
        /// </summary>
        public void DeleteDoor()
        {
            Console.WriteLine("enter door id");
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Color.writeError("input does not number");
            }
            db.deleteDoor(id);
        }

        /// <summary>
        /// удаление обьекта DoorPassing из БД по его id
        /// </summary>
        public void DeleteDoorPassing()
        {
            Console.WriteLine("enter doorPassing id");
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Color.writeError("input does not number");
            }
            db.deleteDoorPassing(id);
        }
        #endregion
    }
}