using Medic.AppModels.CPFiles;
using Medic.Contexts;
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
        private readonly MedicContext MedicContext;

        public CPFileService(MedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
        }
        
        public async Task<List<CPFileSummaryViewModel>> GetSummary()
        {
            return await MedicContext.CPFiles
                .Select(cp => new CPFileSummaryViewModel() { 
                    DateFrom = cp.DateFrom, 
                    InsCount = cp.Ins.Count, 
                    OutsCount = cp.Outs.Count, 
                    PatientTransfersCount = cp.PatientTransfers.Count, 
                    PlannedProceduresCount = cp.PlannedProcedures.Count, 
                    ProtocolDrugTherapiesCount = cp.ProtocolDrugTherapies.Count 
                })
                .OrderBy(cp => cp.DateFrom)
                .ToListAsync();
        }
    }
}