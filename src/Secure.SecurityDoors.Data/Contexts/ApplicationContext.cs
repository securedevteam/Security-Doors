using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Configurations;
using Secure.SecurityDoors.Data.Models;

namespace Secure.SecurityDoors.Data.Contexts
{
    /// <summary>
    /// Application EF Core context.
    /// </summary>
    public class ApplicationContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Contructor with params.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Cards.
        /// </summary>
        public DbSet<Card> Cards { get; set; }

        /// <summary>
        /// Doors.
        /// </summary>
        public DbSet<Door> Doors { get; set; }

        /// <summary>
        /// DoorActions.
        /// </summary>
        public DbSet<DoorAction> DoorActions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CardConfiguration());
            builder.ApplyConfiguration(new DoorConfiguration());
            builder.ApplyConfiguration(new DoorActionConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
