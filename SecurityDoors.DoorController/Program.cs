using System;
using System.Net;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.BusinessLogicLayer.Implementations;
using SecurityDoors.BusinessLogicLayer.Interfaces;

namespace SecurityDoors.DoorController
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "DoorController Application v1.0";

            var serviceProvider = new ServiceCollection()
                .AddTransient<ICardRepository, CardRepository>()
                .AddTransient<IDoorRepository, DoorRepository>()
                .AddTransient<IDoorPassingRepository, DoorPassingRepository>()
                .AddTransient<IPersonRepository, PersonRepository>()
                .AddScoped<DataManager>()
                .BuildServiceProvider();

            var dataManagerService = serviceProvider.GetService<DataManager>();

            var mainController = new MainController(dataManagerService);

            Console.WriteLine("Welcom to the door controller application!");

            Console.Write("Please enter card unique number: ");
            var card = Console.ReadLine();

            Console.Write("Please enter door name: ");
            var door = Console.ReadLine();

            Console.Write("Please enter time to sleep (ms): ");
            var sleep = Console.ReadLine();

            Console.WriteLine("=====");

            while (true)
            {

                Console.Write(string.Format("| {0,15} |", card) +
                              string.Format(" {0,10} |", door));

                var result = mainController.ControllerАctuation(card, door);

                if (result.Item2)
                {
                    var resultString = "OPERATION SUCCEEDED";
                    Console.Write(string.Format("{0,25}", result.Item1) +
                                  string.Format("| {0,20} |", resultString));
                }
                else
                {
                    var resultString = "OPERATION ERROR";
                    Console.Write(string.Format("{0,25}", result.Item1) +
                                  string.Format("| {0,20} |", resultString));
                }

                Console.WriteLine();

                // TODO: Удалить, когда будет возможность использовать моделирование и реализовать прием по TCP.
                Thread.Sleep(Convert.ToInt32(sleep));
            }

        }
    }
}
