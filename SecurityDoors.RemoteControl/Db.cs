using SecurityDoors.DataAccessLayer.Models;
using System;

namespace SecurityDoors.RemoteControl
{
    class Db
    {
        //private static SiteService _siteService;
        /// <summary>
        /// TODO Atention: реализовать, либо не использовать 
        /// </summary>
        /// 
        private static ApplicationContext db = new ApplicationContext();
        public static void init()
        {
            using (var context = new ApplicationContext())
            {

                context.Cards.Add(new Card { UniqueNumber = Guid.NewGuid().ToString(), Status = true });

                var count = context.SaveChanges();

                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All cards in database:");

                foreach (var item in db.Cards)
                {
                    Console.WriteLine(" - {0}", item.UniqueNumber);
                }
            }
        }

        public static void addPerson(Person person)
        {
            db.People.Add(person);
            db.SaveChangesAsync();
        }

        public static void addCard(Card card)
        {
            db.Cards.Add(card);
            db.SaveChangesAsync();
        }

        public static void addDoor(Door door)
        {
            db.Doors.Add(door);
            db.SaveChangesAsync();
        }

        public static Person FindPerson(int id)
        {
            return db.People.Find(id);
        }

        public static Card FindCard(int id)
        {
            return db.Cards.Find(id);
        }
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