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

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SecurityDoorsApplication;Integrated Security=True");

        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	}
}
