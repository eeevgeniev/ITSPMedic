using Medic.AppModels.Diags;
using Medic.Contexts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class DiagService : IDiagService
    {
        private readonly MedicContext MedicContext;

        public DiagService(MedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
        }

        public async Task<List<DiagMKBSummaryViewModel>> GetMKBSummaryAsync()
        {
            return await MedicContext.Diags
                .GroupBy(d => new { d.MKB.Code, d.MKB.Name })
                .Select(g => new DiagMKBSummaryViewModel()
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