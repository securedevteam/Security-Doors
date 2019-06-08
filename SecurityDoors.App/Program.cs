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
                Filter = (source, level) => level >= LogLevel.Warning
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
                logging.AddEventLog(settings);             
            })
            .UseStartup<Startup>()
            .Build();

            webHost.Run();           
        }       
    }
}
