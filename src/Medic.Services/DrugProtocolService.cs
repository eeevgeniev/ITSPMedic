using Medic.Contexts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class DrugProtocolService : IDrugProtocolService
    {
        private readonly MedicContext MedicContext;

        public DrugProtocolService(MedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
        }
        
        public async Task<List<string>> GetDrugProtocolATCNames()
        {
            return await MedicContext.DrugProtocols
                .Select(dp => dp.ATCName)
                .Distinct()
                .ToListAsync();
        }
    }
}
