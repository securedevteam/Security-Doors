using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using SecurityDoors.DataAccessLayer.InitialDbData;
using SecurityDoors.DataAccessLayer.Models;

namespace SecurityDoors.App
{
    public class Program
    {     
        public static void Main(string[] args)
        {
            // В случае отсутсвия журнала, выполнить команду:
            // New-EventLog -LogName SDoorsApplication -Source SecurityDoors.App

            var webHost = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);                
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddEventLog(new EventLogSettings()
                    {
                        SourceName = "SecurityDoors.App",
                        LogName = "SDoorsApplication",
                        Filter = (x, y) => y >= LogLevel.Information
                    });
                    logging.AddConsole();
                })
                .UseStartup<Startup>()
                .Build();

            // Заполнение начальными данными пустую базу данных.
            using (var scope = webHost.Services.CreateScope())
            {
                Task roles, data;
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationContext>();
                    data = DbInitializerData.InitializeAsync(context);
                    data.Wait();

                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    roles = DbInitializerRoles.InitializeAsync(userManager, rolesManager);
                    roles.Wait();
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
