using Medic.App.Infrastructure;
using Medic.AppModels.Sexes;
using Medic.Cache.Contacts;
using Medic.Resources;
using Medic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.App.Controllers.Base
{
    public abstract class SexBaseController : PageBasedController
    {
        private readonly IPatientService _patientService;
        private readonly ICacheable _medicCache;
        private readonly MedicDataLocalization _medicDataLocalization;

        public SexBaseController(IPatientService patientService, ICacheable medicCache, MedicDataLocalization medicDataLocalization)
        {
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            _medicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            _medicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(medicDataLocalization));
        }

        protected IPatientService PatientService => _patientService;
        
        protected ICacheable MedicCache => _medicCache;
        
        protected MedicDataLocalization MedicDataLocalization => _medicDataLocalization;

        protected virtual async Task<List<SexOption>> GetSexesAsync()
        {
            if (!MedicCache.TryGetValue(MedicConstants.SexKeyName, out List<SexOption> sexes))
            {
                sexes = await PatientService.GetSexOptionsAsync();

                MedicCache.Set(MedicConstants.SexKeyName, sexes);
            }

            return sexes;
        }

        protected virtual List<SexOption> GetDefaultSexes() =>
            new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get(MedicDataLocalization.NoSelection) } };
    }
}
