using Medic.Contexts.Contracts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class ClinicUsedDrugsService : IClinicUsedDrugsService
    {
        private readonly IMedicContext MedicContext;

        public ClinicUsedDrugsService(IMedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
        }

        public async Task<List<string>> GetDrugCodesAsync()
        {
            return await MedicContext.ClinicUsedDrugs
                .Select(cud => cud.DrugCode)
                .Distinct()
                .ToListAsync();
        }
    }
}
