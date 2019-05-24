using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.BusinessLogicLayer.Implementations;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;

namespace SecurityDoors.RemoteControl
{
    class Program
    {
        //private static SiteService _siteService;
        //private static ApplicationContext db;

        static void Main(string[] args)
        {

            using (var context = new ApplicationContext())
            {

                context.Cards.Add(new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = true });
                
                
                var count = context.SaveChanges();

                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");

                foreach (var item in context.Cards)
                {
                    Console.WriteLine(" - {0}", item.UniqueNumber);
                }
            }

            // TODO: Постараться сделать.

            //var serviceProvider = new ServiceCollection()

            ////.AddTransient<ICardRepository, CardRepository>()
            ////.AddTransient<IDoorRepository, DoorRepository>()
            ////.AddTransient<IDoorPassingRepository, DoorPassingRepository>()
            ////.AddTransient<IPersonRepository, PersonRepository>()
            ////.AddDbContext<ApplicationContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DoorsApp;Trusted_Connection=True;"))
            ////.AddScoped<DataManager>()
            //.AddDbContext<ApplicationContext>(options =>
            //    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DoorsApp;Trusted_Connection=True;"), ServiceLifetime.Transient)


            //.BuildServiceProvider();

            //var db = serviceProvider.GetRequiredService<ApplicationContext>();

            //db.Cards.Add(new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = true });
            //db.SaveChanges();


            //var services = new ServiceCollection();

            //services.AddTransient<ICardRepository, CardRepository>();
            //services.AddTransient<IDoorRepository, DoorRepository>();
            //services.AddTransient<IDoorPassingRepository, DoorPassingRepository>();
            //services.AddTransient<IPersonRepository, PersonRepository>();

            //services.AddScoped<DataManager>();

            //services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DoorsApp;Trusted_Connection=True;"));

            //var serviceProvider = services.BuildServiceProvider();
            //_siteService = serviceProvider.GetService<SiteService>();
            //_appDbContext = serviceProvider.GetService<ApplicationDbContext>();


            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
