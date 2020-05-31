using Medic.App.Infrastructure;
using Medic.AppModels.Sexes;
using Medic.Cache.Contacts;
using Medic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.App.Controllers.Base
{
    public abstract class SexBaseController : PageBasedController
    {
        protected readonly IPatientService PatientService;
        protected readonly ICacheable MedicCache;

        public SexBaseController(IPatientService patientService, ICacheable medicCache)
        {
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
        }

        protected virtual async Task<List<SexOption>> GetSexes()
        {
            if (!MedicCache.TryGetValue(MedicConstants.SexKeyName, out List<SexOption> sexes))
            {
                sexes = await PatientService.GetSexOptionsAsync();

                MedicCache.Set(MedicConstants.SexKeyName, sexes);
            }

            return sexes;
        }
    }
}
