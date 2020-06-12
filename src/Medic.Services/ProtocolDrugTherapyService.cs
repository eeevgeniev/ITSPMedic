using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.AccompanyingDrugs;
using Medic.AppModels.ChemotherapyParts;
using Medic.AppModels.Diags;
using Medic.AppModels.DrugProtocols;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.HematologyParts;
using Medic.AppModels.Patients;
using Medic.AppModels.Practices;
using Medic.AppModels.ProtocolDrugTherapies;
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
    public class ProtocolDrugTherapyService : BaseServiceHelper, IProtocolDrugTherapyService
    {
        public ProtocolDrugTherapyService(IMedicContext medicContext, MapperConfiguration configuration)
            : base(medicContext, configuration) {}

        public async Task<List<ProtocolDrugTherapyPreviewViewModel>> GetProtocolDrugTherapiesAsync(
            IWhereBuilder<ProtocolDrugTherapy> protocolDrugTherapyBuilder, 
            IHelperBuilder<ProtocolDrugTherapy> helperBuilder, 
            int startIndex)
        {
            if (protocolDrugTherapyBuilder == default)
            {
                throw new ArgumentNullException(nameof(protocolDrugTherapyBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(protocolDrugTherapyBuilder.Where(MedicContext.ProtocolDrugTherapies).Skip(startIndex))
                .ProjectTo<ProtocolDrugTherapyPreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetProtocolDrugTherapiesCountAsync(IWhereBuilder<ProtocolDrugTherapy> protocolDrugTherapyBuilder)
        {
            if (protocolDrugTherapyBuilder == default)
            {
                throw new ArgumentNullException(nameof(protocolDrugTherapyBuilder));
            }

            return await protocolDrugTherapyBuilder.Where(MedicContext.ProtocolDrugTherapies)
                .CountAsync();
        }

        public async Task<ProtocolDrugTherapyViewModel> GetProtocolDrugTherapyAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            return await Task<ProtocolDrugTherapyViewModel>.Run(() =>
            {
                ProtocolDrugTherapy protocolDrugTherapy = MedicContext.ProtocolDrugTherapies
                    .Include(pdt => pdt.PatientBranch)
                        .ThenInclude(pb => pb.HealthRegion)
                    .Include(pdt => pdt.PatientHRegion)
                    .Include(pdt => pdt.CPFile)
                        .ThenInclude(cp => cp.FileType)
                    .SingleOrDefault(pdt => pdt.Id == id);

                if (protocolDrugTherapy == default)
                {
                    return default;
                }

                PatientSummaryViewModel patient = base.GetPatient<PatientSummaryViewModel>(p => p.Id == protocolDrugTherapy.PatientId);

                PracticePreviewViewModel practice = MedicContext.Practices
                    .ProjectTo<PracticePreviewViewModel>(Configuration)
                    .SingleOrDefault(p => p.Id == protocolDrugTherapy.PracticeId);

                DiagPreviewViewModel diag = base.GetDiag<DiagPreviewViewModel>(d => d.Id == protocolDrugTherapy.DiagId);

                HematologyPartPreviewViewModel hematologyPart = MedicContext.HematologyParts
                    .ProjectTo<HematologyPartPreviewViewModel>(Configuration)
                    .SingleOrDefault(hp => hp.Id == protocolDrugTherapy.Id);

                ChemotherapyPartPreviewViewModel chemotherapyPart = MedicContext.ChemotherapyParts
                    .ProjectTo<ChemotherapyPartPreviewViewModel>(Configuration)
                    .SingleOrDefault(cp => cp.Id == protocolDrugTherapy.ChemotherapyPartId);

                List<DrugProtocolPreviewViewModel> drugProtocols = MedicContext.DrugProtocols
                    .Where(dp => dp.ProtocolDrugTherapyId == protocolDrugTherapy.Id)
                    .ProjectTo<DrugProtocolPreviewViewModel>(Configuration)
                    .ToList();

                List<AccompanyingDrugPreviewViewModel> accompanyingDrugs = MedicContext.AccompanyingDrugs
                    .Where(ad => ad.ProtocolDrugTherapyId == protocolDrugTherapy.Id)
                    .ProjectTo<AccompanyingDrugPreviewViewModel>(Configuration)
                    .ToList();

                HealthcarePractitionerSummaryViewModel chairman = 
                    base.GetHealthcarePractitioner<HealthcarePractitionerSummaryViewModel>(hp => hp.Id == protocolDrugTherapy.ChairmanId);

                return new ProtocolDrugTherapyViewModel()
                {
                    Id = protocolDrugTherapy.Id,
                    Patient = patient,
                    PatientBranch = protocolDrugTherapy?.PatientBranch?.HealthRegion?.Name ?? default,
                    PatientHRegion = protocolDrugTherapy?.PatientHRegion?.Name ?? default,
                    Practice = practice,
                    NumberOfDecision = protocolDrugTherapy.NumberOfDecision,
                    DecisionDate = protocolDrugTherapy.DecisionDate,
                    PracticeCodeProtocol = protocolDrugTherapy.PracticeCodeProtocol,
                    NumberOfProtocol = protocolDrugTherapy.NumberOfProtocol,
                    ProtocolDate = protocolDrugTherapy.ProtocolDate,
                    Diag = diag,
                    Height = protocolDrugTherapy.Height,
                    Weight = protocolDrugTherapy.Weight,
                    BSA = protocolDrugTherapy.BSA,
                    TherapyLine = protocolDrugTherapy.TherapyLine,
                    Scheme = protocolDrugTherapy.Scheme,
                    CycleCount = protocolDrugTherapy.CycleCount,
                    HematologyPart = hematologyPart,
                    ChemotherapyPart = chemotherapyPart,
                    DrugProtocols = drugProtocols,
                    AccompanyingDrugs = accompanyingDrugs,
                    Chairman = chairman,
                    Sign = protocolDrugTherapy.Sign,
                    CPFile = protocolDrugTherapy?.CPFile?.FileType.Name,
                };
            });
        }
    }
}
