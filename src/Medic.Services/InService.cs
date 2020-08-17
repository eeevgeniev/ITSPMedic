using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.Diagnoses;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Ins;
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
    public class InService : BaseServiceHelper, IInService
    {
        public InService(IMedicContext medicContext, MapperConfiguration configuration)
            : base (medicContext, configuration) {}

        public async Task<InViewModel> GetInAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            return await Task<InViewModel>.Run(() =>
            {
                In inEntity = MedicContext.Ins
                    .Include(i => i.PatientBranch)
                        .ThenInclude(pb => pb.HealthRegion)
                    .Include(i => i.PatientHRegion)
                    .Include(i => i.CPFile)
                        .ThenInclude(cp => cp.FileType)
                    .SingleOrDefault(i => i.Id == id);

                if (inEntity == default)
                {
                    return default;
                }

                PatientSummaryViewModel patient = MedicContext.Patients
                    .ProjectTo<PatientSummaryViewModel>(Configuration)
                    .SingleOrDefault(p => p.Id == inEntity.PatientId);

                HealthcarePractitionerSummaryViewModel sender = MedicContext.HealthcarePractitioners
                    .ProjectTo<HealthcarePractitionerSummaryViewModel>(Configuration)
                    .SingleOrDefault(hp => hp.Id == inEntity.SenderId);

                List<DiagnosePreviewViewModel> sendDiagnoses = base.GetDiagnoses<DiagnosePreviewViewModel>(d => d.SendInId == inEntity.Id);

                List<DiagnosePreviewViewModel> diagnoses = base.GetDiagnoses<DiagnosePreviewViewModel>(d => d.InId == inEntity.Id);

                return new InViewModel()
                {
                    Id = inEntity.Id,
                    Patient = patient,
                    PatientBranch = inEntity?.PatientBranch?.HealthRegion?.Name ?? default,
                    PatientHRegion = inEntity.PatientHRegion.Name,
                    Sender = sender,
                    InType = inEntity.InType,
                    SendDate = inEntity.SendDate,
                    SendDiagnoses = sendDiagnoses,
                    SendUrgency = inEntity.SendUrgency,
                    SendAPr = inEntity.SendAPr,
                    SendClinicalPath = inEntity.SendClinicalPath,
                    UniqueIdentifier = inEntity.UniqueIdentifier,
                    ExaminationDate = inEntity.ExaminationDate,
                    PlannedNumber = inEntity.PlannedNumber,
                    Diagnoses = diagnoses,
                    Urgency = inEntity.Urgency,
                    InAPr = inEntity.InAPr,
                    ClinicalPath = inEntity.ClinicalPath,
                    NZOKPay = inEntity.NZOKPay,
                    InMedicalWard = inEntity.InMedicalWard,
                    EntryDate = inEntity.EntryDate,
                    Severity = inEntity.Severity,
                    Delay = inEntity.Delay,
                    Payer = inEntity.Payer,
                    AgeInDays = inEntity.AgeInDays,
                    WeightInGrams = inEntity.WeightInGrams,
                    BirthWeight = inEntity.BirthWeight,
                    MotherIZYear = inEntity.MotherIZYear,
                    MotherIZNo = inEntity.MotherIZNo,
                    IZYear = inEntity.IZYear,
                    IZNo = inEntity.IZNo,
                    CPFile = inEntity?.CPFile?.FileType?.Name ?? default
                };
            });
        }

        public async Task<List<InPreviewViewModel>> GetInsAsync(
            IWhereBuilder<In> inBuilder, 
            IHelperBuilder<In> helperBuilder, 
            int startIndex)
        {
            if (inBuilder == default)
            {
                throw new ArgumentNullException(nameof(inBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(inBuilder.Where(MedicContext.Ins).Skip(startIndex))
                .ProjectTo<InPreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetInsCountAsync(IWhereBuilder<In> inBuilder)
        {
            if (inBuilder == default)
            {
                throw new ArgumentNullException(nameof(inBuilder));
            }

            return await inBuilder.Where(MedicContext.Ins)
                .CountAsync();
        }
    }
}
