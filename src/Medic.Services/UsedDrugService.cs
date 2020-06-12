using Medic.AppModels.UsedDrugs;
using Medic.Contexts.Contracts;
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
        private readonly IMedicContext MedicContext;

        public UsedDrugService(IMedicContext medicContext)
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

        public async Task<List<UsedDrugsSummaryStatistic>> UsedDrugsSummaryAsync(int startIndex, int take)
        {
            return await MedicContext.Outs
                .Include(o => o.UsedDrugs)
                .Include(o => o.OutMainDiagnose)
                    .ThenInclude(d => d.Primary)
                .Where(o => o.UsedDrugs.Any(ud => ud.OutId == o.Id))
                .SelectMany(o => o.UsedDrugs)
                .GroupBy(ud => new
                {
                    UsedDrugCode = ud.Code,
                    OutDiagnoseCode = ud.Out.OutMainDiagnose.Primary.Code,
                    OutDiagnoseName = ud.Out.OutMainDiagnose.Primary.Name
                },
                ud => new
                {
                    ud.Quantity,
                    ud.Cost
                })
                .Select((v) => new UsedDrugsSummaryStatistic()
                {
                    UsedDrugCode = v.Key.UsedDrugCode,
                    OutDiagnoseName = v.Key.OutDiagnoseName,
                    OutDiagnoseCode = v.Key.OutDiagnoseCode,
                    TotalUses = v.Count(),
                    AverageQuantity = v.Average(v => v.Quantity),
                    TotalCosts = v.Sum(v => v.Cost)
                })
                .OrderBy(v => v.UsedDrugCode)
                .ThenByDescending(v => v.TotalUses)
                .Skip(startIndex)
                .Take(take)
                .ToListAsync();
        }

        public async Task<int> UsedDrugsSummaryCountAsync()
        {
            return await MedicContext.Outs
                .Include(o => o.UsedDrugs)
                .Include(o => o.SendDiagnoses)
                    .ThenInclude(sd => sd.Primary)
                .Include(o => o.OutMainDiagnose)
                    .ThenInclude(d => d.Primary)
                .Where(o => o.UsedDrugs.Any(ud => ud.OutId == o.Id))
                .SelectMany(o => o.UsedDrugs)
                .GroupBy(ud => new
                {
                    UsedDrugCode = ud.Code,
                    OutDiagnoseCode = ud.Out.OutMainDiagnose.Primary.Code,
                    OutDiagnoseName = ud.Out.OutMainDiagnose.Primary.Name
                },
                ud => new
                {
                    ud.Quantity,
                    ud.Cost
                })
                .Select((v) => new UsedDrugsSummaryStatistic()
                {
                    UsedDrugCode = v.Key.UsedDrugCode,
                    OutDiagnoseName = v.Key.OutDiagnoseName,
                    OutDiagnoseCode = v.Key.OutDiagnoseCode,
                    TotalUses = v.Count(),
                    AverageQuantity = v.Average(v => v.Quantity),
                    TotalCosts = v.Sum(v => v.Cost)
                })
                .CountAsync();
        }
    }
}
