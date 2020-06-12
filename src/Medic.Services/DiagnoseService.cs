using Medic.AppModels.Diagnoses;
using Medic.Contexts.Contracts;
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
        private readonly IMedicContext MedicContext;

        public DiagnoseService(IMedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
        }

        public async Task<int> GetMKBSummaryCountAsync()
        {
            return await GetModel().CountAsync();
        }

        public async Task<List<DiagnoseMKBSummaryViewModel>> MKBSummaryAsync(int startIndex, int take)
        {
            return await GetModel()
                .OrderByDescending(d => d.Count)
                .Skip(startIndex)
                .Take(take)
                .ToListAsync();
        }

        private IQueryable<DiagnoseMKBSummaryViewModel> GetModel()
        {
            return MedicContext.Diagnoses
                .GroupBy(d => new { d.Primary.Code, d.Primary.Name })
                .Select(g => new DiagnoseMKBSummaryViewModel()
                {
                    Code = g.Key.Code,
                    Name = g.Key.Name,
                    Count = g.Count()
                });
        }
    }
}
