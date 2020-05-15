using AutoMapper;
using Medic.Cache;
using Medic.Cache.Contacts;
using Medic.Contexts;
using Medic.Identity;
using Medic.Infrastructure;
using Medic.Logs;
using Medic.Logs.Contracts;
using Medic.Mappers;
using Medic.Mappers.Contracts;
using Medic.Resources;
using Medic.Services;
using Medic.Services.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using MC = Medic.App.Infrastructure;

namespace Medic.App.AppServices
{
    public static class ConfigureAppServices
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            if (configuration == default)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (environment == default)
            {
                throw new ArgumentNullException(nameof(environment));
            }
            
            services.AddTransient<IMappable, AMapper>();

            services.AddDbContext<MedicContext>(options =>
            {
                options.UseSqlServer(configuration[MedicConstants.ConnectionString]);
            });

            services.AddDbContext<MedicIdentityContext>(options =>
            {
                options.UseSqlServer(configuration[MedicConstants.IdentityConnectionString]);
            });

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 10;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
            })
            .AddEntityFrameworkStores<MedicIdentityContext>();

            services.AddTransient<ICPFileService, CPFileService>();
            services.AddTransient<IDiagnoseService, DiagnoseService>();
            services.AddTransient<IDiagService, DiagService>();
            services.AddTransient<IHospitalPracticeService, HospitalPracticeService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IInService, InService>();
            services.AddTransient<IOutService, OutService>();
            services.AddTransient<IUsedDrugService, UsedDrugService>();
            services.AddTransient<IInClinicProcedureService, InClinicProcedureService>();
            services.AddTransient<IPathProcedureService, PathProcedureService>();
            services.AddTransient<IHealthRegionService, HealthRegionService>();
            services.AddTransient<IProtocolDrugTherapyService, ProtocolDrugTherapyService>();
            services.AddTransient<ICommissionAprService, CommissionAprService>();

            services.AddTransient<PatientLocalization>();
            services.AddTransient<MedicDataLocalization>();
            services.AddTransient<GeneralLocalization>();

            services.BuildServiceProvider().GetRequiredService<MedicContext>();

            AMapperConfiguration mapConfiguration = new AMapperConfiguration();

            services.AddSingleton<MapperConfiguration>(mapConfiguration.CreateConfiguration());
            services.AddSingleton<ICacheable>(new MedicCache());

            services.AddDbContext<MedicLoggerContext>(options =>
            {
                options.UseSqlite($"Data Source={Path.Combine(environment.ContentRootPath, "Logs\\Logs.sqlite")}");
            });

            services.AddTransient<IMedicLoggerService, MedicLoggerService>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            MedicContextSeeder medicContextSeeder = new MedicContextSeeder(
                serviceProvider.GetRequiredService<MedicIdentityContext>(),
                serviceProvider.GetRequiredService<UserManager<IdentityUser>>(), 
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>());

            medicContextSeeder.Seed(new List<(string username, string password, string email)>()
            {
                (
                    configuration[MC.MedicConstants.AdministratorName],
                    configuration[MC.MedicConstants.AdministratorPassword],
                    configuration[MC.MedicConstants.AdministratorEmail]
                )
            }).Wait();

            serviceProvider.GetRequiredService<MedicLoggerContext>().Database.EnsureCreated();

            return services;
        }
    }
}