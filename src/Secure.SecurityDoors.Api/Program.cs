using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Secure.SecurityDoors.Api.Resources;
using Secure.SecurityDoors.Shared.Constants;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;

namespace Secure.SecurityDoors.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                 .Enrich.FromLogContext()
                 .WriteTo.Console()
                 .WriteTo.MSSqlServer(
                    connectionString: AppConstant.ConnectionString,
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        AutoCreateSqlTable = true,
                        TableName = "Logs",
                    })
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
                    webBuilder.UseUrls("https://localhost:5003", "http://localhost:5002");
                });
    }
}
