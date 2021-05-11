﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Secure.SecurityDoors.Data.Contexts;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.DatabaseSeed.Interfaces;
using Secure.SecurityDoors.DatabaseSeed.Resources;
using Secure.SecurityDoors.DatabaseSeed.Services;
using System;

namespace Secure.SecurityDoors.DatabaseSeed
{
    class Program
    {
        public static void Main(string[] args)
        {
            var creationService = GetServiceProvider()
                .GetRequiredService<ICreationService>();

            if (Question("role"))
            {
                creationService.CreateRole()
                    .GetAwaiter()
                    .GetResult();
            }

            Console.WriteLine();

            if (Question("user"))
            {
                creationService.CreateUser()
                    .GetAwaiter()
                    .GetResult();
            }
        }

        private static bool Question(string model)
        {
            const string actionСancellation = "n";

            Console.Write(string.Format(MessageResource.QuestionCreate, model));
            var userInput = Console.ReadLine();
            return !string.IsNullOrWhiteSpace(userInput) && userInput.ToLower() != actionСancellation;
        }

        private static ServiceProvider GetServiceProvider()
        {
            const string connectionString =
                "Server=(localdb)\\mssqllocaldb;Database=SecurityDoorsApp;Trusted_Connection=True;";

            var services = new ServiceCollection()
                .AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(connectionString))
                .AddSingleton<ILoggerFactory, LoggerFactory>()
                .AddSingleton(typeof(ILogger<>), typeof(Logger<>))
                .AddScoped<ICreationService, CreationService>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

            return services.BuildServiceProvider();
        }
    }
}