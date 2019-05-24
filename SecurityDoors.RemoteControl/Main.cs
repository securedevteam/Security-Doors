using System;

namespace SecurityDoors.RemoteControl
{
    class Main
    {
        public static void main(String[] args)
        {
            Console.WriteLine("Wellcome to remoute Controll system");
            Console.WriteLine("type quit to exit program");
            Console.WriteLine("aviable command: " +
                "add-person || a-p" +
                "add-door   || a-d" +
                "add-card   || a-c");
            while (!Console.ReadLine().Equals("quit"))
            {
                switch (Console.ReadLine())
                {
                    case "add person":
                    case "a-p":
                        if (Command.addPerson())
                        {
                            Console.WriteLine("person added succesfull");
                        } else
                        {
                            Console.WriteLine("person added failed");
                        } 
                        break;
                    case "add-door":
                    case "a-d":
                        if (Command.addDoor())
                        {
                            Console.WriteLine("door added succesfull");
                        }
                        else
                        {
                            Console.WriteLine("door added failed");
                        }
                        break;
                    case "add-card":
                    case "a-c":
                        if (Command.addCard())
                        {
                            Console.WriteLine("card added succesfull");
                        }
                        else
                        {
                            Console.WriteLine("card added failed");
                        }
                        break;
                }
            }
        }


    }
}
