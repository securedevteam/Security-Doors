using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SecurityDoors.Core.StaticClasses;
using SecurityDoors.DataAccessLayer.Models;

namespace SecurityDoors.App
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionString = ConnectionStringConfiguration.GetConnectionString();
            builder.UseSqlServer(connectionString);

            return new ApplicationContext(builder.Options);
        }
    }
}
