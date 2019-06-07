using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.Tests
{
    class TestContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<DoorPassing> DoorPassings { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
