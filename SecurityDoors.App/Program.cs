using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using SecurityDoors.DataAccessLayer;
using SecurityDoors.DataAccessLayer.Models;

namespace SecurityDoors.App
{
    public class Program
    {     
        public static void Main(string[] args)
        {
            

            string logName = "SDoorsApplication";
            string sourceName = "SecurityDoors.App";

            if (EventLog.SourceExists(sourceName) == false)
            {
                var eventSourceData = new EventSourceCreationData(sourceName, logName);
                EventLog.CreateEventSource(eventSourceData);
            }

            var settings = new EventLogSettings
            {
                LogName = "SDoorsApplication",
                SourceName = "SDoorsApplication",
                Filter = (source, level) => level >= LogLevel.Information
            };
            var webHost = new WebHostBuilder().UseKestrel().UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);                
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));                
                logging.AddEventLog(settings);             
            })
            .UseStartup<Startup>()
            .Build();

            // Заполнение начальными данными пустую базу данных.
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            webHost.Run();           
        }       
    }
}
