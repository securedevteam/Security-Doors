﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecurityDoors.DataAccessLayer.Models;

namespace SecurityDoors.DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SecurityDoors.DataAccessLayer.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<int>("Level");

                    b.Property<bool>("Location");

                    b.Property<int>("Status");

                    b.Property<string>("UniqueNumber");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("SecurityDoors.DataAccessLayer.Models.Door", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Doors");
                });

            modelBuilder.Entity("SecurityDoors.DataAccessLayer.Models.DoorPassing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardId");

                    b.Property<string>("Comment");

                    b.Property<int>("DoorId");

                    b.Property<bool>("Location");

                    b.Property<DateTime>("PassingTime");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("DoorId");

                    b.ToTable("DoorPassings");
                });

            modelBuilder.Entity("SecurityDoors.DataAccessLayer.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardId");

                    b.Property<string>("Comment");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("Passport");

                    b.Property<string>("SecondName");

                    b.HasKey("Id");

                    b.HasIndex("CardId")
                        .IsUnique();

                    b.ToTable("People");
                });

            modelBuilder.Entity("SecurityDoors.DataAccessLayer.Models.DoorPassing", b =>
                {
                    b.HasOne("SecurityDoors.DataAccessLayer.Models.Card", "Card")
                        .WithMany("DoorPassings")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SecurityDoors.DataAccessLayer.Models.Door", "Door")
                        .WithMany("DoorPassings")
                        .HasForeignKey("DoorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecurityDoors.DataAccessLayer.Models.Person", b =>
                {
                    b.HasOne("SecurityDoors.DataAccessLayer.Models.Card", "Card")
                        .WithOne("Person")
                        .HasForeignKey("SecurityDoors.DataAccessLayer.Models.Person", "CardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
