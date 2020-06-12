using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.Diagnoses;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Patients;
using Medic.AppModels.Plannings;
using Medic.Contexts.Contracts;
using Medic.Entities;
using Medic.Services.Base;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class PlannedService : BaseServiceHelper, IPlannedService
    {
        public PlannedService(IMedicContext medicContext, MapperConfiguration configuration)
            : base (medicContext, configuration) {}

        public async Task<PlannedViewModel> GetPlannedAsync(int id)
        {
            return await Task<PlannedViewModel>.Run(() =>
            {
                Planned planned = MedicContext.Plannings
                    .Include(o => o.PatientBranch)
                        .ThenInclude(pb => pb.HealthRegion)
                    .Include(o => o.PatientHRegion)
                    .SingleOrDefault(p => p.Id == id);

                if (planned == default)
                {
                    return default;
                }

                PatientSummaryViewModel patient = base.GetPatient<PatientSummaryViewModel>(p => p.Id == planned.PatientId);

                HealthcarePractitionerSummaryViewModel sender = 
                    base.GetHealthcarePractitioner<HealthcarePractitionerSummaryViewModel>(hp => hp.Id == planned.SenderId);

                List<DiagnosePreviewViewModel> sendDiagnose = base.GetDiagnoses<DiagnosePreviewViewModel>(d => d.SendPlannedId == planned.Id);

                List<DiagnosePreviewViewModel> diagnose = base.GetDiagnoses<DiagnosePreviewViewModel>(d => d.PlannedId == planned.Id);

                return new PlannedViewModel()
                {
                    Id = planned.Id,
                    Patient = patient,
                    PatientBranch = planned?.PatientBranch?.HealthRegion?.Name ?? default,
                    PatientHRegion = planned?.PatientHRegion?.Name ?? default,
                    InType = planned.InType,
                    Sender = sender,
                    SendDate = planned.SendDate,
                    SendDiagnoses = sendDiagnose,
                    SendUrgency = planned.SendUrgency,
                    SendClinicalPath = planned.SendClinicalPath,
                    UniqueIdentifier = planned.UniqueIdentifier,
                    ExaminationDate = planned.ExaminationDate,
                    PlannedEntryDate = planned.PlannedEntryDate,
                    PlannedNumber = planned.PlannedNumber,
                    Diagnoses = diagnose,
                    Urgency = planned.Urgency,
                    ClinicalPath = planned.ClinicalPath,
                    NZOKPay = planned.NZOKPay
                };
            });
        }

        public async Task<List<PlannedPreviewViewModel>> GetPlanningsAsync(
            IWhereBuilder<Planned> plannedProcedureBuilder, 
            IHelperBuilder<Planned> helperBuilder, 
            int startIndex)
        {
            if (plannedProcedureBuilder == default)
            {
                throw new ArgumentNullException(nameof(plannedProcedureBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(plannedProcedureBuilder.Where(MedicContext.Plannings).Skip(startIndex))
                .ProjectTo<PlannedPreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetPlanningsCountAsync(IWhereBuilder<Planned> plannedProcedureBuilder)
        {
            if (plannedProcedureBuilder == default)
            {
                throw new ArgumentNullException(nameof(plannedProcedureBuilder));
            }
            
            return await plannedProcedureBuilder.Where(MedicContext.Plannings)
                .CountAsync(); 
        }
    }
}
