using System;
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

            mainController.ControllerАctuation(card, door);

            
            Console.ReadLine();
        }
    }
}
