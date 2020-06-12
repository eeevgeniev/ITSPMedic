using Medic.AppModels.CPFiles;
using Medic.Contexts.Contracts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class CPFileService : ICPFileService
    {
        private readonly IMedicContext MedicContext;

        public CPFileService(IMedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
        }
        
        public async Task<List<CPFileSummaryViewModel>> GetSummaryAsync()
        {
            return await GetSummary();
        }

        public async Task<List<CPFileSummaryViewModel>> GetSummaryByMonthAsync()
        {
            List<CPFileSummaryViewModel> summaries = await GetSummary();
            HashSet<CPFileSummaryViewModel> summariesByDate = new HashSet<CPFileSummaryViewModel>(new SummaryByMonthComaprer());
            CPFileSummaryViewModel current;

            if (summaries != default && summaries.Count > 0)
            {
                foreach (CPFileSummaryViewModel model in summaries)
                {
                    if (summariesByDate.TryGetValue(model, out current))
                    {
                        current.InsCount += model.InsCount;
                        current.OutsCount += model.OutsCount;
                        current.PatientTransfersCount += model.PatientTransfersCount;
                        current.PlanningsCount += model.PlanningsCount;
                        current.ProtocolDrugTherapiesCount += model.ProtocolDrugTherapiesCount;
                    }
                    else
                    {
                        current = new CPFileSummaryViewModel()
                        {
                            DateFrom = new DateTime(model.DateFrom.Year, model.DateFrom.Month, 1),
                            InsCount = model.InsCount,
                            OutsCount = model.OutsCount,
                            PatientTransfersCount = model.PatientTransfersCount,
                            PlanningsCount = model.PlanningsCount,
                            ProtocolDrugTherapiesCount = model.ProtocolDrugTherapiesCount
                        };

                        summariesByDate.Add(current);
                    }
                }
            }

            return summariesByDate.ToList();
        }

        private async Task<List<CPFileSummaryViewModel>> GetSummary()
        {
            return await MedicContext.CPFiles
                    .Include(cp => cp.Ins)
                    .Include(cp => cp.Outs)
                    .Include(cp => cp.Transfers)
                    .Include(cp => cp.Plannings)
                    .Include(cp => cp.ProtocolDrugTherapies)
                .Select(cp => new CPFileSummaryViewModel()
                {
                    DateFrom = cp.DateFrom,
                    InsCount = cp.Ins.Count,
                    OutsCount = cp.Outs.Count,
                    PatientTransfersCount = cp.Transfers.Count,
                    PlanningsCount = cp.Plannings.Count,
                    ProtocolDrugTherapiesCount = cp.ProtocolDrugTherapies.Count
                })
                .OrderBy(cp => cp.DateFrom)
                .ToListAsync();
        }

        private class SummaryByMonthComaprer : IEqualityComparer<CPFileSummaryViewModel>
        {
            public bool Equals(CPFileSummaryViewModel x, CPFileSummaryViewModel y)
            {
                if (x == default)
                {
                    throw new ArgumentNullException(nameof(x));
                }

                if (y == default)
                {
                    throw new ArgumentNullException(nameof(y));
                }

                return x.DateFrom.Month == y.DateFrom.Month && x.DateFrom.Year == y.DateFrom.Year;
            }

            public int GetHashCode(CPFileSummaryViewModel obj)
            {
                if (obj == default || obj.DateFrom == null)
                {
                    throw new ArgumentNullException(nameof(obj));
                }

                return ($"{obj.DateFrom.Month}-{obj.DateFrom.Year}").GetHashCode();
            }
        }
    }
}