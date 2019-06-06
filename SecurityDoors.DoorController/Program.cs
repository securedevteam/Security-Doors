using System;
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
            var serviceProvider = new ServiceCollection()    
                .AddTransient<ICardRepository, CardRepository>()
                .AddTransient<IDoorRepository, DoorRepository>()
                .AddTransient<IDoorPassingRepository, DoorPassingRepository>()
                .AddTransient<IPersonRepository, PersonRepository>()
                .AddScoped<DataManager>()
                .BuildServiceProvider();

            var dataManagerService = serviceProvider.GetService<DataManager>();

            var mainController = new MainController(dataManagerService);

            var card = Console.ReadLine();
            var door = Console.ReadLine();

            Console.WriteLine("===");

            while (true)
            {
                //var card = Console.ReadLine();
                //var door = Console.ReadLine();




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

                Thread.Sleep(1000);
            }

            

            Console.ReadLine();
        }
    }
}
