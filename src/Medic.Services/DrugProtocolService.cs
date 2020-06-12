using Medic.Contexts.Contracts;
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
        private readonly IMedicContext MedicContext;

        public DrugProtocolService(IMedicContext medicContext)
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
