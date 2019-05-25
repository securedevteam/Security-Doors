using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SecurityDoors.DataAccessLayer.Models
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Person> People { get; set; }
		public DbSet<Card> Cards { get; set; }
		public DbSet<Door> Doors { get; set; }
		public DbSet<DoorPassing> DoorPassings { get; set; }

		/// <summary>
		/// При отсутствии бд - создает пустую БД с нужной структурой
		/// </summary>
		public ApplicationContext()
		{
			Database.EnsureCreated();
		}


        //public EquipmentAccountingContext(DbContextOptions<EquipmentAccountingContext> options) : base(options)
        //{
        //    Database.EnsureCreated();
        //}

		/// <summary>
		/// Устанавливает строку подключения из файла конфигураций к localDb
		/// Вариации строк можно посмотреть здесь https://www.connectionstrings.com/sql-server/
		/// </summary>
		protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
		{
            // TODO: Удалить после приведение кода в порядок.

            //var builder = new ConfigurationBuilder();
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //builder.AddJsonFile("appsettings.json");
            //var config = builder.Build();
            //string connectionString = config.GetConnectionString("DefaultConnection");

            //if (!optionsBuilder.IsConfigured)
            //{
            //	optionsBuilder.UseSqlServer(connectionString);
            //}

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DoorsApp;Integrated Security=True");

        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			/// TODO: Решить с автозаполнением данных
			/// БД заполнится ими в 2-х случаях, если в конструкторе будет EnsureCreated или в случае миграции
			/// EnsureDeleted только формирует структуру
			#region Автозаполнение (закоментировано)
			/*
			modelBuilder.Entity<Card>().HasData(
				new Card[]
				{
					new Card { Id = 1, UniqueNumber = Guid.NewGuid().ToString(), Status = true},
					new Card { Id = 2, UniqueNumber = Guid.NewGuid().ToString(), Status = false},
					new Card { Id = 3, UniqueNumber = Guid.NewGuid().ToString(), Status = false},
					new Card { Id = 4, UniqueNumber = Guid.NewGuid().ToString(), Status = false},
					new Card { Id = 5, UniqueNumber = Guid.NewGuid().ToString(), Status = true},
					new Card { Id = 6, UniqueNumber = Guid.NewGuid().ToString(), Status = true},
					new Card { Id = 7, UniqueNumber = Guid.NewGuid().ToString(), Status = false},
					new Card { Id = 8, UniqueNumber = Guid.NewGuid().ToString(), Status = true},
					new Card { Id = 9, UniqueNumber = Guid.NewGuid().ToString(), Status = false},
					new Card { Id = 10, UniqueNumber = Guid.NewGuid().ToString(), Status = false},
				}
				);
			modelBuilder.Entity<Person>().HasData(
				new Person[]
				{
				new Person { Id=1, FirstName="Иван", SecondName = "Иванович", LastName = "Иванов", Gender = true, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 1},
				new Person { Id=2, FirstName="Петр", SecondName = "Петрович", LastName = "Петров", Gender = true, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 5},
				new Person { Id=3, FirstName="Михаил", SecondName = "Михайлович", LastName = "Михайлов", Gender = true, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 6},
				new Person { Id=4, FirstName="Алексей", SecondName = "Алексеевич", LastName = "Алсексеев", Gender = true, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 8},
				new Person { Id=5, FirstName="Юрий", SecondName = "Юрьевич", LastName = "Юрьев", Gender = true, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 10},
				new Person { Id=6, FirstName="Василиса", SecondName = "Васильевна", LastName = "Вась", Gender = false, Passport = $"{new Random().Next(1000, 9000).ToString()} {new Random().Next(100000, 900000).ToString()}", CardId = 2},
				});
			modelBuilder.Entity<Door>().HasData(
				new Door[]
				{
					new Door { Id = 1, Name = "Парадная", Description = "Основной вход"},
					new Door { Id = 2, Name = "Вход для персонала", Description = "Основной вход для персонала"},
				});
			modelBuilder.Entity<DoorPassing>().HasData(
				new DoorPassing[]
				{
					new DoorPassing { Id = 1, DoorId = 1, PersonId = 1 },
					new DoorPassing { Id = 2, DoorId = 1, PersonId = 2},
					new DoorPassing { Id = 3, DoorId = 1, PersonId = 3},
					new DoorPassing { Id = 4, DoorId = 1, PersonId = 4},
					new DoorPassing { Id = 5, DoorId = 2, PersonId = 5},
					new DoorPassing { Id = 6, DoorId = 2, PersonId = 6}
				});
				*/
			#endregion
			base.OnModelCreating(modelBuilder);
		}
	}
}
