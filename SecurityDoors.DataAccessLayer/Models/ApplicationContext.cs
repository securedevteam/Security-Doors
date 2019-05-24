using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SecurityDoors.DataAccessLayer.Models
{
	class ApplicationContext : DbContext
	{
		public DbSet<Person> People { get; set; }
		public DbSet<Card> Cards { get; set; }
		public DbSet<Door> Doors { get; set; }

		/// <summary>
		/// При отсутствии бд - создает пустую БД с нужной структурой
		/// </summary>
		public ApplicationContext()
		{
			Database.EnsureCreated();
		}

		/// <summary>
		/// Устанавливает строку подключения из файла конфигураций к localDb
		/// Вариации строк можно посмотреть здесь https://www.connectionstrings.com/sql-server/
		/// </summary>
		protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder();
			builder.SetBasePath(Directory.GetCurrentDirectory());
			builder.AddJsonFile("appsettings.json");
			var config = builder.Build();
			string connectionString = config.GetConnectionString("DefaultConnection");

			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(connectionString);
			}
		}
	}
}
