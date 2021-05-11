using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Secure.SecurityDoors.Web.Resources;
using Serilog;
using Serilog.Events;
using System;

namespace Secure.SecurityDoors.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information(CommonResource.HostStart);
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, CommonResource.HostFatalError);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("https://localhost:5001", "http://localhost:5000");
                });
    }
}
