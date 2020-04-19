using Medic.AppModels.HospitalPractices;
using Medic.Contexts;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class HospitalPracticeService : IHospitalPracticeService
    {
        private readonly MedicContext MedicContext;

        public HospitalPracticeService(MedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
        }

        public async Task<List<HospitalPracticeSummaryViewModel>> GetSummary()
        {
            return await MedicContext.HospitalPractices
                .Select(hp => new HospitalPracticeSummaryViewModel() 
                { 
                    DateFrom = hp.DateFrom, 
                    CommissionAprsCount = hp.CommissionAprs.Count,
                    DispObservationsCount = hp.DispObservations.Count,
                    ProtocolDrugTherapiesCount = hp.ProtocolDrugTherapies.Count,
                    InClinicProceduresCount = hp.InClinicProcedures.Count,
                    PathProceduresCount = hp.PathProcedures.Count,
                    PatientTransfersCount = hp.PatientTransfers.Count
                })
                .OrderBy(hp => hp.DateFrom)
                .ToListAsync();
        }
    }
}
