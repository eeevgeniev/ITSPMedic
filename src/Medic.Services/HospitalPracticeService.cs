using Medic.AppModels.HospitalPractices;
using Medic.Contexts.Contracts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class HospitalPracticeService : IHospitalPracticeService
    {
        private readonly IMedicContext MedicContext;

        public HospitalPracticeService(IMedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
        }

        public async Task<List<HospitalPracticeSummaryViewModel>> GetSummaryAsync()
        {
            return await GetSummary();
        }

        public async Task<List<HospitalPracticeSummaryViewModel>> GetSummaryByMonthAsync()
        {
            List<HospitalPracticeSummaryViewModel> summaries = await GetSummary();
            HashSet<HospitalPracticeSummaryViewModel> summariesByDate = new HashSet<HospitalPracticeSummaryViewModel>(new SummaryByMonthComaprer());
            HospitalPracticeSummaryViewModel current;

            if (summaries != default && summaries.Count > 0)
            {
                foreach (HospitalPracticeSummaryViewModel model in summaries)
                {
                    if (summariesByDate.TryGetValue(model, out current))
                    {
                        current.CommissionAprsCount += model.CommissionAprsCount;
                        current.DispObservationsCount += model.DispObservationsCount;
                        current.InClinicProceduresCount += model.InClinicProceduresCount;
                        current.PathProceduresCount += model.PathProceduresCount;
                        current.ProtocolDrugTherapiesCount += model.ProtocolDrugTherapiesCount;
                        current.PatientTransfersCount += model.PatientTransfersCount;
                    }
                    else
                    {
                        current = new HospitalPracticeSummaryViewModel()
                        {
                            DateFrom = new DateTime(model.DateFrom.Year, model.DateFrom.Month, 1),
                            CommissionAprsCount = model.CommissionAprsCount,
                            DispObservationsCount = model.DispObservationsCount,
                            PatientTransfersCount = model.PatientTransfersCount,
                            InClinicProceduresCount = model.InClinicProceduresCount,
                            ProtocolDrugTherapiesCount = model.ProtocolDrugTherapiesCount,
                            PathProceduresCount = model.PathProceduresCount
                        };

                        summariesByDate.Add(current);
                    }
                }
            }

            return summariesByDate.ToList();
        }

        private async Task<List<HospitalPracticeSummaryViewModel>> GetSummary()
        {
            return await MedicContext.HospitalPractices
                .Include(hp => hp.CommissionAprs)
                .Include(hp => hp.DispObservations)
                .Include(hp => hp.ProtocolDrugTherapies)
                .Include(hp => hp.InClinicProcedures)
                .Include(hp => hp.PathProcedures)
                .Include(pt => pt.Transfers)
                .Select(hp => new HospitalPracticeSummaryViewModel()
                {
                    DateFrom = hp.DateFrom,
                    CommissionAprsCount = hp.CommissionAprs.Count,
                    DispObservationsCount = hp.DispObservations.Count,
                    ProtocolDrugTherapiesCount = hp.ProtocolDrugTherapies.Count,
                    InClinicProceduresCount = hp.InClinicProcedures.Count,
                    PathProceduresCount = hp.PathProcedures.Count,
                    PatientTransfersCount = hp.Transfers.Count
                })
                .OrderBy(hp => hp.DateFrom)
                .ToListAsync();
        }

        private class SummaryByMonthComaprer : IEqualityComparer<HospitalPracticeSummaryViewModel>
        {
            public bool Equals(HospitalPracticeSummaryViewModel x, HospitalPracticeSummaryViewModel y)
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

            public int GetHashCode(HospitalPracticeSummaryViewModel obj)
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
