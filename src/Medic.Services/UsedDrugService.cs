using Medic.AppModels.UsedDrugs;
using Medic.Contexts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class UsedDrugService : IUsedDrugService
    {
        private readonly MedicContext MedicContext;

        public UsedDrugService(MedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
        }
        
        public async Task<List<UsedDrugCodeOption>> UsedDrugsByCodeAsync()
        {
            return await MedicContext.UsedDrugs
                    .Select(ud => ud.Code)
                    .Distinct()
                    .Select(code => new UsedDrugCodeOption() { Key = code, Code = code })
                    .ToListAsync();
        }
    }
}
