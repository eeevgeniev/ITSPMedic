using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.CeasedClinicals;
using Medic.AppModels.ClinicProcedures;
using Medic.AppModels.ClinicUsedDrugs;
using Medic.AppModels.Diags;
using Medic.AppModels.DoneProcedures;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.PathProcedures;
using Medic.AppModels.Patients;
using Medic.AppModels.Procedures;
using Medic.Contexts.Contracts;
using Medic.Entities;
using Medic.Services.Base;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class PathProcedureService : BaseServiceHelper, IPathProcedureService
    {
        public PathProcedureService(IMedicContext medicContext, MapperConfiguration configuration)
            : base (medicContext, configuration) {}

        public async Task<List<PathProcedurePreviewViewModel>> GetPathProceduresAsync(
            IWhereBuilder<PathProcedure> pathProcedureBuilder, 
            IHelperBuilder<PathProcedure> helperBuilder, 
            int startIndex)
        {
            if (pathProcedureBuilder == default)
            {
                throw new ArgumentNullException(nameof(pathProcedureBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(pathProcedureBuilder.Where(MedicContext.PathProcedures).Skip(startIndex))
                .ProjectTo<PathProcedurePreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetPathProceduresCountAsync(IWhereBuilder<PathProcedure> pathProcedureBuilder)
        {
            if (pathProcedureBuilder == default)
            {
                throw new ArgumentNullException(nameof(pathProcedureBuilder));
            }

            return await pathProcedureBuilder.Where(MedicContext.PathProcedures)
                .CountAsync();
        }

        public async Task<PathProcedureViewModel> GetPathProcedureByIdAsync(int id)
        {
            return await Task<PathProcedureViewModel>.Run(() =>
            {
                PathProcedure pathProcedure = MedicContext.PathProcedures
                    .Include(pp => pp.PatientBranch)
                        .ThenInclude(pb => pb.HealthRegion)
                    .Include(pp => pp.PatientHRegion)
                    .SingleOrDefault(pp => pp.Id == id);

                if (pathProcedure == default)
                {
                    return default;
                }

                PatientSummaryViewModel patient = base.GetPatient<PatientSummaryViewModel>(p => p.Id == pathProcedure.PatientId);

                HealthcarePractitionerSummaryViewModel sender = 
                    base.GetHealthcarePractitioner<HealthcarePractitionerSummaryViewModel>(hp => hp.Id == pathProcedure.SenderId);

                CeasedClinicalViewModel CeasedProcedure = base.GetCeasedClinical<CeasedClinicalViewModel>(cc => cc.Id == pathProcedure.CeasedProcedureId);

                CeasedClinicalViewModel CeasedClinicalPath = base.GetCeasedClinical<CeasedClinicalViewModel>(cc => cc.Id == pathProcedure.CeasedClinicalPathId);

                DiagPreviewViewModel firstMainDiag = base.GetDiag<DiagPreviewViewModel>(d => d.Id == pathProcedure.FirstMainDiagId);

                DiagPreviewViewModel secondMainDiag = base.GetDiag<DiagPreviewViewModel>(d => d.Id == pathProcedure.SecondMainDiagId);

                List<ProcedureSummaryViewModel> doneNewProcedures = base.GetProcedures<ProcedureSummaryViewModel>(pr => pr.PathProcedureId == pathProcedure.Id);

                List<ClinicUsedDrugViewModel> usedDrugs = MedicContext.ClinicUsedDrugs
                    .Where(ud => ud.PathProcedureId == pathProcedure.Id)
                    .ProjectTo<ClinicUsedDrugViewModel>(Configuration)
                    .ToList();

                List<ClinicProcedureViewModel> clinicProcedure = MedicContext.ClinicProcedures
                    .Where(cp => cp.PathProcedureId == pathProcedure.Id)
                    .ProjectTo<ClinicProcedureViewModel>(Configuration)
                    .ToList();

                List<DoneProcedureViewModel> doneProcedures = MedicContext.DoneProcedures
                    .Where(dp => dp.PathProcedureId == pathProcedure.Id)
                    .ProjectTo<DoneProcedureViewModel>(Configuration)
                    .ToList();

                return new PathProcedureViewModel()
                {
                    Id = pathProcedure.Id,
                    Patient = patient,
                    PatientBranch = pathProcedure?.PatientBranch?.HealthRegion?.Name ?? default,
                    PatientHRegion = pathProcedure?.PatientHRegion?.Name ?? default,
                    Sender = sender,
                    CPrSend = pathProcedure.CPrSend,
                    APrSend = pathProcedure.APrSend,
                    TypeProcSend = pathProcedure.TypeProcSend,
                    DateSend = pathProcedure.DateSend,
                    CPrPriem = pathProcedure.CPrPriem,
                    APrPriem = pathProcedure.APrPriem,
                    MedicalWard = pathProcedure.MedicalWard,
                    TypeProcPriem = pathProcedure.TypeProcPriem,
                    ProcRefuse = pathProcedure.ProcRefuse,
                    CeasedProcedure = CeasedProcedure,
                    CeasedClinicalPath = CeasedClinicalPath,
                    IZNumChild = pathProcedure.IZNumChild,
                    IZYearChild = pathProcedure.IZYearChild,
                    FirstVisitDate = pathProcedure.FirstVisitDate,
                    DatePlanPriem = pathProcedure.DatePlanPriem,
                    VisitDoctorUniqueIdentifier = pathProcedure.VisitDoctorUniqueIdentifier,
                    VisitDoctorName = pathProcedure.VisitDoctorName,
                    FirstMainDiag = firstMainDiag,
                    SecondMainDiag = secondMainDiag,
                    DateProcedureBegins = pathProcedure.DateProcedureBegins,
                    DateProcedureEnd = pathProcedure.DateProcedureEnd,
                    DoneNewProcedures = doneNewProcedures,
                    UsedDrugs = usedDrugs,
                    ClinicProcedures = clinicProcedure,
                    DoneProcedures = doneProcedures,
                    AllDoneProcedures = pathProcedure.AllDoneProcedures,
                    AllDrugCost = pathProcedure.AllDrugCost,
                    PatientStatus = pathProcedure.PatientStatus,
                    OutUniqueIdentifier = pathProcedure.OutUniqueIdentifier,
                    Sign = pathProcedure.Sign,
                    NZOKPay = pathProcedure.NZOKPay
                };
            });
        }
    }
}