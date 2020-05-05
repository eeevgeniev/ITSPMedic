using Medic.App.AppServices;
using Medic.App.Infrastructure;
using Medic.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Medic.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get;  }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        MedicDataAnnotationLocalizerProvider medicDataAnnotationLocalizerProvider =
                            new MedicDataAnnotationLocalizerProvider();

                        return medicDataAnnotationLocalizerProvider.Build(factory);
                    };
                });

            services.ConfigureServices(Configuration, Environment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                string value = MedicConstants.DefaultLanguage;

                if (context.Request.Cookies.TryGetValue(MedicConstants.LanguageCookieName, out string newValue))
                {
                    if (!string.IsNullOrWhiteSpace(newValue))
                    {
                        newValue = newValue.ToLower();

                        if (MedicConstants.AllowedLanguages.Contains(newValue.ToLower()))
                        {
                            value = newValue;
                        }
                    }
                }
                
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(value);
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(value);

                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
