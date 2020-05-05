using AutoMapper;
using Medic.Contexts;
using Medic.Identity;
using Medic.Infrastructure;
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

            services.AddDbContext<MedicIdentity>(options =>
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
            .AddEntityFrameworkStores<MedicIdentity>();

            services.AddTransient<ICPFileService, CPFileService>();
            services.AddTransient<IDiagnoseService, DiagnoseService>();
            services.AddTransient<IDiagService, DiagService>();
            services.AddTransient<IHospitalPracticeService, HospitalPracticeService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IInService, InService>();
            services.AddTransient<IOutService, OutService>();
            services.AddTransient<IUsedDrugService, UsedDrugService>();

            services.AddTransient<PatientLocalization>();
            services.AddTransient<MedicDataLocalization>();
            services.AddTransient<GeneralLocalization>();

            services.BuildServiceProvider().GetRequiredService<MedicContext>();

            AMapperConfiguration mapConfiguration = new AMapperConfiguration();

            services.AddSingleton<MapperConfiguration>(mapConfiguration.CreateConfiguration());

            return services;
        }
    }
}