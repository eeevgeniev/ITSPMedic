using Medic.AppModels.Diagnoses;
using Medic.Contexts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class DiagnoseService : IDiagnoseService
    {
        private readonly MedicContext MedicContext;

        public DiagnoseService(MedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
        }

        public async Task<List<DiagnosesMKBSummaryViewModel>> MKBSummary()
        {
            return await MedicContext.Diagnoses
                .GroupBy(d => new { d.Primary.Code, d.Primary.Name })
                .Select(g => new DiagnosesMKBSummaryViewModel()
                {
                    Code = g.Key.Code,
                    Name = g.Key.Name,
                    Count = g.Count()
                })
                .OrderByDescending(d => d.Count)
                .ToListAsync();
        }
    }
}
