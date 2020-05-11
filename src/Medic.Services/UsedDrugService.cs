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

        public async Task<List<UsedDrugsSummaryStatistic>> UsedDrugsSummaryAsync()
        {
            return await MedicContext.Outs
                .Include(o => o.UsedDrug)
                .Include(o => o.SendDiagnose)
                    .ThenInclude(sd => sd.Primary)
                .Include(o => o.OutMainDiagnose)
                    .ThenInclude(d => d.Primary)
                .Where(o => o.UsedDrugId != default)
                .GroupBy(o => new
                    {
                        UsedDrugCode = o.UsedDrug.Code,
                        SendDignoseCode = o.SendDiagnose.Primary.Code,
                        SendDiagnoseName = o.SendDiagnose.Primary.Name,
                        OutDiagnoseCode = o.OutMainDiagnose.Primary.Code,
                        OutDiagnoseName = o.OutMainDiagnose.Primary.Name
                    },
                    o => new
                    {
                        o.UsedDrug.Quantity,
                        o.UsedDrug.Cost
                    })
                .Select((v) => new UsedDrugsSummaryStatistic()
                {
                    UsedDrugCode = v.Key.UsedDrugCode,
                    SendDiagnoseName = v.Key.SendDiagnoseName,
                    SendDignoseCode = v.Key.SendDignoseCode,
                    OutDiagnoseName = v.Key.OutDiagnoseName,
                    OutDiagnoseCode = v.Key.OutDiagnoseCode,
                    TotalUses = v.Count(),
                    AverageQuantity = v.Average(v => v.Quantity),
                    TotalCosts = v.Sum(v => v.Cost)
                })
                .OrderBy(v => v.OutDiagnoseCode)
                .ThenByDescending(v => v.TotalUses)
                .ToListAsync();
        }
    }
}
