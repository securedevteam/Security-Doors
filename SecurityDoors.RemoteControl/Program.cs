﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.BusinessLogicLayer.Implementations;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.RemoteControl.cli;
using System;

namespace SecurityDoors.RemoteControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "RemoteControll Application v1.0";

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SecurityDoorsApplication;Trusted_Connection=True;MultipleActiveResultSets=true"));

            serviceCollection.AddScoped<ICardRepository, CardRepository>();
            serviceCollection.AddScoped<IDoorRepository, DoorRepository>();
            serviceCollection.AddScoped<IDoorPassingRepository, DoorPassingRepository>();
            serviceCollection.AddScoped<IPersonRepository, PersonRepository>();

            serviceCollection.AddScoped<DataManager>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dataManagerService = serviceProvider.GetService<DataManager>();
            var applicationContext = serviceProvider.GetService<ApplicationContext>();

            CommandLineInterface cli = new CommandLineInterface(dataManagerService, applicationContext);
            _ = cli.Run(); // TODO: Разобраться почему так (!)
        }
    }
}