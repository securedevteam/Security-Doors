using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SecurityDoors.App.Logger;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.BusinessLogicLayer.Implementations;
using SecurityDoors.BusinessLogicLayer.Interfaces;

namespace SecurityDoors.App
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies 
                // is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Добавлен DI
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<IDoorRepository, DoorRepository>();
            services.AddTransient<IDoorPassingRepository, DoorPassingRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            services.AddScoped<DataManager>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                // TODO: Поменять с добавлением контроллера Home
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Card}/{action=Index}/{id?}");
            });

            // TODO: На текущий момент нету необходимости в этом. (Не удалять!)
            //app.Run(async (context) =>
            //{
            //    logger.LogInformation("Processing request {0}", context.Request.Path);
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
