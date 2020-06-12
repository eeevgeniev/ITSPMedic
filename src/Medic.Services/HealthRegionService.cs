using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.HealthRegions;
using Medic.Contexts.Contracts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class HealthRegionService : IHealthRegionService
    {
        private readonly IMedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public HealthRegionService(IMedicContext medicContext, MapperConfiguration configuration)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<List<HealthRegionOption>> GetHealthRegionsAsync()
        {
            return await MedicContext
                .HealthRegions
                .OrderBy(hr => hr.Name)
                .ProjectTo<HealthRegionOption>(Configuration)
                .ToListAsync();
        }
    }
}
