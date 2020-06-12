using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.CeasedClinicals;
using Medic.AppModels.Diags;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.InClinicProcedures;
using Medic.AppModels.Patients;
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
    public class InClinicProcedureService : BaseServiceHelper, IInClinicProcedureService
    {
        public InClinicProcedureService(IMedicContext medicContext, MapperConfiguration configuration)
            : base (medicContext, configuration) { }

        public async Task<InClinicProcedureViewModel> GetInClinicProcedureAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return await Task<InClinicProcedureViewModel>.Run(() =>
            {
                InClinicProcedure inClinicProcedure = MedicContext.InClinicProcedures
                    .Include(icp => icp.PatientBranch)
                        .ThenInclude(pb => pb.HealthRegion)
                    .Include(icp => icp.PatientHealthRegion)
                    .SingleOrDefault(icp => icp.Id == id);

                if (inClinicProcedure == default)
                {
                    return default;
                }

                PatientSummaryViewModel patient = base.GetPatient<PatientSummaryViewModel>(p => p.Id == inClinicProcedure.PatientId);

                HealthcarePractitionerSummaryViewModel sender = 
                    base.GetHealthcarePractitioner<HealthcarePractitionerSummaryViewModel>(hp => hp.Id == inClinicProcedure.SenderId);

                CeasedClinicalViewModel ceasedClinical = base.GetCeasedClinical<CeasedClinicalViewModel>(cc => cc.Id == inClinicProcedure.CeasedClinicalPathId);

                DiagPreviewViewModel firstMainDiag = base.GetDiag<DiagPreviewViewModel>(d => d.Id == inClinicProcedure.FirstMainDiagId);

                DiagPreviewViewModel secondMainDiag = base.GetDiag<DiagPreviewViewModel>(d => d.Id == inClinicProcedure.SecondMainDiagId);

                return new InClinicProcedureViewModel()
                {
                    Id = inClinicProcedure.Id,
                    Patient = patient,
                    PatientBranch = inClinicProcedure?.PatientBranch?.HealthRegion?.Name ?? default,
                    PatientHealthRegion = inClinicProcedure.PatientHealthRegion.Name,
                    Sender = sender,
                    APrSend = inClinicProcedure.APrSend,
                    TypeProcSend = inClinicProcedure.TypeProcSend,
                    DateSend = inClinicProcedure.DateSend,
                    CPrPriem = inClinicProcedure.CPrPriem,
                    APrPriem = inClinicProcedure.APrPriem,
                    TypeProcPriem = inClinicProcedure.TypeProcPriem,
                    ProcRefuse = inClinicProcedure.ProcRefuse,
                    CeasedClinicalPath = ceasedClinical,
                    IZNumChild = inClinicProcedure.IZNumChild,
                    IZYearChild = inClinicProcedure.IZYearChild,
                    FirstVisitDate = inClinicProcedure.FirstVisitDate,
                    PlanVisitDate = inClinicProcedure.PlanVisitDate,
                    VisitDocumentUniqueIdentifier = inClinicProcedure.VisitDocumentUniqueIdentifier,
                    VisitDocumentName = inClinicProcedure.VisitDocumentName,
                    FirstMainDiag = firstMainDiag,
                    SecondMainDiag = secondMainDiag,
                    PatientStatus = inClinicProcedure.PatientStatus,
                    NZOKPay = inClinicProcedure.NZOKPay
                };
            });
        }

        public async Task<List<InClinicProcedurePreviewViewModel>> GetInClinicProceduresAsync(
            IWhereBuilder<InClinicProcedure> inClinicProcedureBuilder, 
            IHelperBuilder<InClinicProcedure> helperBuilder, 
            int startIndex)
        {
            if (inClinicProcedureBuilder == default)
            {
                throw new ArgumentNullException(nameof(inClinicProcedureBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(inClinicProcedureBuilder.Where(MedicContext.InClinicProcedures).Skip(startIndex))
                .ProjectTo<InClinicProcedurePreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetInClinicProceduresCountAsync(IWhereBuilder<InClinicProcedure> inClinicProcedureBuilder)
        {
            if (inClinicProcedureBuilder == default)
            {
                throw new ArgumentNullException(nameof(inClinicProcedureBuilder));
            }

            return await inClinicProcedureBuilder.Where(MedicContext.InClinicProcedures)
                .CountAsync();
        }
    }
}