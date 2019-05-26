using System;


namespace SecurityDoors.RemoteControl
{

    class Command
    {
        public static bool addPerson()
        {
            Console.WriteLine("Enter name");
            Console.WriteLine("Enter second name");
            Console.WriteLine("Enter last name");
            Console.WriteLine("Enter gander");
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
