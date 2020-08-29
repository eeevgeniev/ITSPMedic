using Medic.App.Infrastructure;
using Medic.AppModels.HealthRegions;
using Medic.Cache.Contacts;
using Medic.Formatters.Contracts;
using Medic.Resources;
using Medic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.App.Controllers.Base
{
    public abstract class LookupsBaseController : SexBaseController
    {
        private readonly IHealthRegionService _healthRegionService;

        public LookupsBaseController(IPatientService patientService,
            IHealthRegionService healthRegionService,
            ICacheable medicCache,
            MedicDataLocalization medicDataLocalization)
            : base (patientService, medicCache, medicDataLocalization)
        {
            _healthRegionService = healthRegionService ?? throw new ArgumentNullException(nameof(healthRegionService));
        }

        protected IHealthRegionService HealthRegionService => _healthRegionService;

        protected virtual async Task<List<HealthRegionOption>> GetHealthRegionsAsync()
        {
            if (!base.MedicCache.TryGetValue(MedicConstants.HealthRegionsKeyName, out List<HealthRegionOption> regions))
            {
                regions = await HealthRegionService.GetHealthRegionsAsync();

                base.MedicCache.Set(MedicConstants.HealthRegionsKeyName, regions);
            }

            return regions;
        }

        protected virtual List<HealthRegionOption> GetDefaultHealthRegions() =>
            new List<HealthRegionOption>() { new HealthRegionOption() { Id = null, Name = MedicDataLocalization.Get(MedicDataLocalization.NoSelection) } };
    }
}
