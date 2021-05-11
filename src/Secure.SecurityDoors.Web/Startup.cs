using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using Secure.SecurityDoors.Data.Contexts;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Interfaces;
using Secure.SecurityDoors.Logic.Managers;
using Serilog;
using System.Globalization;
using System.Reflection;

namespace Secure.SecurityDoors.Web
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

            // Database context
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApplicationConnection")));

            // ASP.NET Core Identity
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            // Microsoft services & etc
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddControllersWithViews()
                .AddDataAnnotationsLocalization()
                .AddViewLocalization()
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("ru")
                };

                options.DefaultRequestCulture = new RequestCulture("ru");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Secure.SecurityDoors.Cookie";
            });

            services.AddAutoMapper(
                Assembly.Load("Secure.SecurityDoors.Logic"),
                Assembly.Load("Secure.SecurityDoors.Web"));

            var mailKitOptions = Configuration.GetSection("Mail").Get<MailKitOptions>();
            services.AddMailKit(optionBuilder =>
            {
                optionBuilder.UseMailKit(new MailKitOptions()
                {
                    Server = mailKitOptions.Server,
                    Port = mailKitOptions.Port,
                    SenderName = mailKitOptions.SenderName,
                    SenderEmail = mailKitOptions.SenderEmail,
                    Account = mailKitOptions.Account,
                    Password = mailKitOptions.Password,
                    Security = true
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //var supportedCultures = new[]
            //{
            //    new CultureInfo("en"),
            //    new CultureInfo("ru"),
            //    new CultureInfo("de")
            //};
            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture("ru"),
            //    SupportedCultures = supportedCultures,
            //    SupportedUICultures = supportedCultures
            //});

            app.UseRequestLocalization();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
