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

            var list = dataManagerService.Cards.GetCardsList();

            foreach(var item in list)
            {
                Console.WriteLine($"{item.Id} {item.UniqueNumber} {item.Level} {item.Status}");
            }

            Console.ReadLine();
        }
    }
}
