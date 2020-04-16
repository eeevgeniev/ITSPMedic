using AutoMapper;
using Medic.Contexts;
using Medic.Infrastructure;
using Medic.Mappers;
using Medic.Mappers.Contracts;
using Medic.Services;
using Medic.Services.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Medic.App.AppServices
{
    public static class ConfigureAppServices
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration Configuration, IWebHostEnvironment Environment)
        {
            services.AddTransient<MapperConfiguration>(serviceProvider =>
            {
                AMapperConfiguration mapConfiguration = new AMapperConfiguration();

                return mapConfiguration.CreateConfiguration();
            });
            
            services.AddTransient<IMappable, AMapper>();

            services.AddDbContext<MedicContext>(options =>
            {
                options.UseSqlServer(MedicConstants.ConnectionString);
            });

            services.AddTransient<IPatientService, PatientService>();

            return services;
        }
    }
}