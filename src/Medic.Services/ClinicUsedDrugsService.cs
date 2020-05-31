using Medic.Contexts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class ClinicUsedDrugsService : IClinicUsedDrugsService
    {
        private readonly MedicContext MedicContext;

        public ClinicUsedDrugsService(MedicContext medicContext)
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
