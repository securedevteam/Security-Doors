using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.BusinessLogicLayer.Implementations;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;

namespace SecurityDoors.Tests
{
    /// <summary>
    /// Вспомогательный класс для внедрения DI и InMemoryDatabase.
    /// </summary>
    public class ServiceFixture
    {
        /// <summary>
        /// Набор сервисов.
        /// </summary>
        public ServiceProvider ServiceProvider { get; private set; }


        /// <summary>
        /// Конструктор.
        /// </summary>
        public ServiceFixture()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()), ServiceLifetime.Transient);

            serviceCollection.AddScoped<ICardRepository, CardRepository>();
            serviceCollection.AddScoped<IDoorRepository, DoorRepository>();
            serviceCollection.AddScoped<IDoorPassingRepository, DoorPassingRepository>();
            serviceCollection.AddScoped<IPersonRepository, PersonRepository>();

            serviceCollection.AddScoped<DataManager>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }   
}
