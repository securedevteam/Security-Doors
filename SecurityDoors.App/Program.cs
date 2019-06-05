﻿using System;
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

namespace SecurityDoors.App
{
    public class Program
    {     
        public static void Main(string[] args)
        {
            string logName = "Secure.App";
            string sourceName = "SecurityDoors";
            if (!EventLog.SourceExists(sourceName))
            {
                var eventSourceData = new EventSourceCreationData(sourceName, logName);
				
				EventLog.CreateEventSource(sourceName, logName);
            }
			
            var settings = new EventLogSettings
            {
                LogName = logName,
                SourceName = sourceName,
                Filter = (source, level) => level >= LogLevel.Debug
            };
            var webHost = new WebHostBuilder().UseKestrel().UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", 
                          optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables();
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole(options => options.IncludeScopes = true);
                logging.AddEventLog(settings);             
            })
            .UseStartup<Startup>()
            .Build();

            webHost.Run();           
        }       
    }
}
