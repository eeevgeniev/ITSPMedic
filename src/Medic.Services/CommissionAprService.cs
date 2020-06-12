using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.APr05s;
using Medic.AppModels.APr38s;
using Medic.AppModels.CommissionAprs;
using Medic.AppModels.Diags;
using Medic.AppModels.HealthcarePractitioners;
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
    public class CommissionAprService : BaseServiceHelper, ICommissionAprService
    {
        public CommissionAprService(IMedicContext medicContext, MapperConfiguration configuration)
            : base (medicContext, configuration) {}

        public async Task<CommissionAprViewModel> GetCommissionAprAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            return await Task<CommissionAprViewModel>.Run(() =>
            {
                CommissionApr commissionApr = MedicContext.CommissionAprs
                    .Include(ca => ca.PatientBranch)
                        .ThenInclude(pb => pb.HealthRegion)
                    .Include(ca => ca.PatientHRegion)
                    .SingleOrDefault(ca => ca.Id == id);

                if (commissionApr == default)
                {
                    return default;
                }

                PatientSummaryViewModel patient = base.GetPatient<PatientSummaryViewModel>(p => p.Id == commissionApr.PatientId);

                HealthcarePractitionerSummaryViewModel sender = 
                    base.GetHealthcarePractitioner<HealthcarePractitionerSummaryViewModel>(hp => hp.Id == commissionApr.SenderId);

                HealthcarePractitionerSummaryViewModel chairman = 
                    base.GetHealthcarePractitioner<HealthcarePractitionerSummaryViewModel>(hp => hp.Id == commissionApr.ChairmanId);

                DiagPreviewViewModel mainDiag = base.GetDiag<DiagPreviewViewModel>(d => d.Id == commissionApr.MainDiagId);

                List<DiagPreviewViewModel> addedDiag = base.GetDiags<DiagPreviewViewModel>(d => d.CommissionAprId == commissionApr.Id);

                APr38PreviewViewModel APr38 = MedicContext.APr38s
                    .ProjectTo<APr38PreviewViewModel>(Configuration)
                    .SingleOrDefault(apr => apr.Id == commissionApr.APr38Id);

                APr05PreviewViewModel APr05 = MedicContext.APr05s
                    .ProjectTo<APr05PreviewViewModel>(Configuration)
                    .SingleOrDefault(apr => apr.Id == commissionApr.APr05Id);

                return new CommissionAprViewModel()
                {
                    Id = commissionApr.Id,
                    Patient = patient,
                    PatientBranch = commissionApr?.PatientBranch?.HealthRegion?.Name ?? default,
                    PatientHRegion = commissionApr.PatientHRegion.Name,
                    Sender = sender,
                    AprSend = commissionApr.AprSend,
                    SendDate = commissionApr.SendDate,
                    AprPriem = commissionApr.AprPriem,
                    SpecCommission = commissionApr.SpecCommission,
                    NoDecision = commissionApr.NoDecision,
                    DecisionDate = commissionApr.DecisionDate,
                    Chairman = chairman,
                    MainDiag = mainDiag,
                    AddDiags = addedDiag,
                    APr38 = APr38,
                    APr05 = APr05,
                    Sign = commissionApr.Sign,
                    NZOKPay = commissionApr.NZOKPay
                };
            });
        }

        public async Task<List<CommissionAprPreviewViewModel>> GetCommissionAprsAsync(
            IWhereBuilder<CommissionApr> commissionAprWhereBuilder, 
            IHelperBuilder<CommissionApr> helperBuilder, 
            int startIndex)
        {
            if (commissionAprWhereBuilder == default)
            {
                throw new ArgumentNullException(nameof(commissionAprWhereBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(commissionAprWhereBuilder.Where(MedicContext.CommissionAprs).Skip(startIndex))
                .ProjectTo<CommissionAprPreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetCommissionAprsCountAsync(IWhereBuilder<CommissionApr> commissionAprWhereBuilder)
        {
            if (commissionAprWhereBuilder == default)
            {
                throw new ArgumentNullException(nameof(commissionAprWhereBuilder));
            }

            return await commissionAprWhereBuilder.Where(MedicContext.CommissionAprs)
                .CountAsync();
        }
    }
}