using System;


namespace SecurityDoors.RemoteControl
{

    class Command
    {
        public static bool addPerson()
        {
            Console.WriteLine("Enter name");
            Console.WriteLine("Enter second name");
            Console.WriteLine("Enter last name")
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter gander\n1) - male\n2) - female");
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
            throw new NotImplementedException();
        }

        internal static bool addDoor()
        {
            Console.WriteLine("Enter name");
            Console.WriteLine("Enter description");
            throw new NotImplementedException();
        }

        internal static bool addCard()
        {
            Console.WriteLine("Enter name");
            throw new NotImplementedException();
        }
    }
}
