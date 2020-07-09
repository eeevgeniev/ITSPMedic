using Medic.App.Infrastructure;
using Medic.AppModels.HealthRegions;
using Medic.Cache.Contacts;
using Medic.Resources;
using Medic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.App.Controllers.Base
{
    public abstract class LookupsBaseController : SexBaseController
    {
        protected readonly IHealthRegionService HealthRegionService;

        public LookupsBaseController(IPatientService patientService,
            IHealthRegionService healthRegionService,
            ICacheable medicCache,
            MedicDataLocalization medicDataLocalization)
            : base (patientService, medicCache, medicDataLocalization)
        {
            HealthRegionService = healthRegionService ?? throw new ArgumentNullException(nameof(healthRegionService));
        }

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
