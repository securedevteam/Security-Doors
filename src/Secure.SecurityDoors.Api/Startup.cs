using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Secure.SecurityDoors.Api.Extensions;
using Secure.SecurityDoors.Data.Contexts;
using Secure.SecurityDoors.Logic.Interfaces;
using Secure.SecurityDoors.Logic.Managers;
using Secure.SecurityDoors.Shared.Constants;
using Serilog;
using System.Reflection;

namespace Secure.SecurityDoors.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Managers & services
            services.AddScoped<ICardManager, CardManager>();
            services.AddScoped<IDoorActionManager, DoorActionManager>();
            services.AddScoped<IDoorReaderManager, DoorReaderManager>();
            services.AddScoped<ICommitManager, CommitManager>();

            // Database context
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(AppConstant.ConnectionString));

            // Microsoft services & etc
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Secure.SecurityDoors.Api",
                    Version = "v1"
                });
            });

            services.AddAutoMapper(Assembly.Load("Secure.SecurityDoors.Logic"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "Secure.SecurityDoors.Api v1"));

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCustomErrorHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
