using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.BusinessLogicLayer.Implementations;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.Core.StaticClasses;
using SecurityDoors.DataAccessLayer.Models;
using System.Globalization;

namespace SecurityDoors.App
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }
       
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies 
                // is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var connectionString = ConnectionStringConfiguration.GetConnectionString();

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

			services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationContext>();

            // Добавлен DI
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IDoorRepository, DoorRepository>();
            services.AddScoped<IDoorPassingRepository, DoorPassingRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSingleton<DataManager>();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "SecurityDoors API", Version = "v1" }));

            services.AddMvc()
                .AddViewLocalization()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {                       
            if (env.IsDevelopment())
            {                
                app.UseDeveloperExceptionPage();
                _logger.LogInformation("In Development environment");
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            var supportedCultures = new[]
            {
                new CultureInfo("ru-RU"),
                new CultureInfo("en-US")  
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru-RU"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SecurityDoors API version 1"));
            app.UseHttpsRedirection();
            app.UseStatusCodePagesWithRedirects("/Errors/{0}.html");
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
