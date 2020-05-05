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

        public async Task<List<DiagnoseMKBSummaryViewModel>> MKBSummaryAsync()
        {
            return await MedicContext.Diagnoses
                .Where(d => d.MainInId != null || d.OutId != null)
                .GroupBy(d => new { d.Primary.Code, d.Primary.Name })
                .Select(g => new DiagnoseMKBSummaryViewModel()
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
