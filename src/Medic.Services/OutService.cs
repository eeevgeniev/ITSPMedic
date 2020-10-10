using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.Diagnoses;
using Medic.AppModels.Epicrisises;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.HistologicalResult;
using Medic.AppModels.Outs;
using Medic.AppModels.Patients;
using Medic.AppModels.Procedures;
using Medic.AppModels.UsedDrugs;
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
    public class OutService : BaseServiceHelper, IOutService
    {
        public OutService(IMedicContext medicContext, MapperConfiguration configuration)
            : base (medicContext, configuration){}

        public async Task<OutViewModel> GetOutAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            return await Task<OutViewModel>.Run(() =>
            {
                Out outEntity = MedicContext.Outs
                    .Include(o => o.PatientBranch)
                        .ThenInclude(pb => pb.HealthRegion)
                    .Include(o => o.PatientHRegion)
                    .Include(o => o.CPFile)
                        .ThenInclude(cp => cp.FileType)
                    .SingleOrDefault(o => o.Id == id);

                if (outEntity == default)
                {
                    return default;
                }

                PatientSummaryViewModel patient = base.GetPatient<PatientSummaryViewModel>(p => p.Id == outEntity.PatientId);

                HealthcarePractitionerSummaryViewModel sender = 
                    base.GetHealthcarePractitioner<HealthcarePractitionerSummaryViewModel>(hp => hp.Id == outEntity.SenderId);

                List<DiagnosePreviewViewModel> sendDiagnoses = base.GetDiagnoses<DiagnosePreviewViewModel>(d => d.SendOutId == outEntity.Id);

                List<DiagnosePreviewViewModel> diagnoses = base.GetDiagnoses<DiagnosePreviewViewModel>(d => d.OutId == outEntity.Id);

                DiagnosePreviewViewModel dead = base.GetDiagnose<DiagnosePreviewViewModel>(d => d.Id == outEntity.DeadId);

                HistologicalResultSummaryViewModel histologicalResult = MedicContext.HistologicalResults
                    .ProjectTo<HistologicalResultSummaryViewModel>(Configuration)
                    .SingleOrDefault(hr => hr.Id == outEntity.HistologicalResultId);

                EpicrisisSummaryViewModel epicrisis = MedicContext.Epicrises
                    .ProjectTo<EpicrisisSummaryViewModel>(Configuration)
                    .SingleOrDefault(e => e.Id == outEntity.EpicrisisId);

                DiagnosePreviewViewModel outMainDiagnose = base.GetDiagnose<DiagnosePreviewViewModel>(d => d.Id == outEntity.OutMainDiagnoseId);

                List<DiagnosePreviewViewModel> outDiagnoses = base.GetDiagnoses<DiagnosePreviewViewModel>(d => d.OutOutId == outEntity.Id);

                List<UsedDrugSummaryViewModel> usedDrugs = MedicContext.UsedDrugs
                    .Where(ud => ud.OutId == outEntity.Id)
                    .ProjectTo<UsedDrugSummaryViewModel>(Configuration)
                    .ToList();

                List<ProcedureSummaryViewModel> procedures = base.GetProcedures<ProcedureSummaryViewModel>(p => p.OutId == outEntity.Id);

                return new OutViewModel()
                {
                    Id = outEntity.Id,
                    Patient = patient,
                    PatientBranch = outEntity?.PatientBranch?.HealthRegion?.Name ?? default,
                    PatientHRegion = outEntity?.PatientHRegion?.Name ?? default,
                    Sender = sender,
                    InType = outEntity.InType,
                    SendDate = outEntity.SendDate,
                    SendDiagnoses = sendDiagnoses,
                    SendUrgency = outEntity.SendUrgency,
                    SendClinicalPath = outEntity.SendClinicalPath,
                    SendAPr = outEntity.SendAPr,
                    PlannedNumber = outEntity.PlannedNumber,
                    InAPr = outEntity.InAPr,
                    UniqueIdentifier = outEntity.UniqueIdentifier,
                    ExaminationDate = outEntity.ExaminationDate,
                    Diagnoses = diagnoses,
                    Urgency = outEntity.Urgency,
                    ClinicalPath = outEntity.ClinicalPath,
                    NZOKPay = outEntity.NZOKPay,
                    InMedicalWard = outEntity.InMedicalWard,
                    EntryDate = outEntity.EntryDate,
                    Severity = outEntity.Severity,
                    Delay = outEntity.Delay,
                    Payer = outEntity.Payer,
                    AgeInDays = outEntity.AgeInDays,
                    WeightInGrams = outEntity.WeightInGrams,
                    BirthWeight = outEntity.BirthWeight,
                    MotherIZYear = outEntity.MotherIZYear,
                    MotherIZNo = outEntity.MotherIZNo,
                    IZYear = outEntity.IZYear,
                    IZNo = outEntity.IZNo,
                    OutMedicalWard = outEntity.OutMedicalWard,
                    OutUniqueIdentifier = outEntity.OutUniqueIdentifier,
                    OutDate = outEntity.OutDate,
                    OutType = outEntity.OutType,
                    Dead = dead,
                    BirthPractice = outEntity.BirthPractice,
                    BirthNumber = outEntity.BirthNumber,
                    BirthGestWeek = outEntity.BirthGestWeek,
                    OutClinicalPath = outEntity.OutClinicalPath,
                    OutAPr = outEntity.OutAPr,
                    HistologicalResult = histologicalResult,
                    Epicrisis = epicrisis,
                    OutMainDiagnose = outMainDiagnose,
                    OutDiagnoses = outDiagnoses,
                    UsedDrugs = usedDrugs,
                    Procedures = procedures,
                    BedDays = outEntity.BedDays,
                    HLDateFrom = outEntity.HLDateFrom,
                    HLNumber = outEntity.HLNumber,
                    HLTotalDays = outEntity.HLTotalDays,
                    StateAtDischarge = outEntity.StateAtDischarge,
                    Laparoscopic = outEntity.Laparoscopic,
                    EndCourse = outEntity.EndCourse,
                    CPFile = outEntity?.CPFile?.FileType?.Name ?? default
                };
            });
        }

        public async Task<List<OutPreviewViewModel>> GetOutsAsync(
            IWhereBuilder<Out> outBuilder, 
            IHelperBuilder<Out> helperBuilder, 
            int startIndex)
        {
            if (outBuilder == default)
            {
                throw new ArgumentNullException(nameof(outBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }
            
            return await helperBuilder.BuildQuery(outBuilder.Where(MedicContext.Outs).Skip(startIndex))
                .ProjectTo<OutPreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetOutsCountAsync(IWhereBuilder<Out> outBuilder)
        {
            if (outBuilder == default)
            {
                throw new ArgumentNullException(nameof(outBuilder));
            }

            return await outBuilder.Where(MedicContext.Outs)
                .CountAsync();
        }
    }
}
