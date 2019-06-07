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

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
