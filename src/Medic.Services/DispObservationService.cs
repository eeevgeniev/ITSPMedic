using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.Diags;
using Medic.AppModels.DispObservations;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.MDIs;
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
    public class DispObservationService : BaseServiceHelper, IDispObservationService
    {
        public DispObservationService(IMedicContext medicContext, MapperConfiguration configuration)
            : base (medicContext, configuration) {}

        public async Task<DispObservationViewModel> GetDispObservationAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            return await Task<DispObservationViewModel>.Run(() =>
            {
                DispObservation dispObservation = MedicContext.DispObservations
                    .Include(disp => disp.PatientBranch)
                        .ThenInclude(pb => pb.HealthRegion)
                    .Include(disp => disp.PatientHRegion)
                    .SingleOrDefault(disp => disp.Id == id);

                if (dispObservation == default)
                {
                    return default;
                }

                PatientSummaryViewModel patient = base.GetPatient<PatientSummaryViewModel>(p => p.Id == dispObservation.PatientId);

                HealthcarePractitionerSummaryViewModel doctor = 
                    base.GetHealthcarePractitioner<HealthcarePractitionerSummaryViewModel>(hp => hp.Id == dispObservation.DoctorId);

                List<MDISummaryViewModel> MDIs = MedicContext.MDIs
                    .Where(m => m.DispObservationId == dispObservation.Id)
                    .ProjectTo<MDISummaryViewModel>(Configuration)
                    .ToList();

                DiagPreviewViewModel firstMainDiag = GetDiag<DiagPreviewViewModel>(d => d.Id == dispObservation.MainDiagFirstId);

                DiagPreviewViewModel secondMainDiag = GetDiag<DiagPreviewViewModel>(d => d.Id == dispObservation.MainDiagSecondId);

                return new DispObservationViewModel()
                {
                    Id = dispObservation.Id,
                    Patient = patient,
                    PatientBranch = dispObservation?.PatientBranch?.HealthRegion?.Name ?? default,
                    PatientHRegion = dispObservation?.PatientHRegion?.Name ?? default,
                    Doctor = doctor,
                    DispNum = dispObservation.DispNum,
                    DispDate = dispObservation.DispDate,
                    AprCode = dispObservation.AprCode,
                    DiagDate = dispObservation.DiagDate,
                    DispanserDate = dispObservation.DispanserDate,
                    DispVisit = dispObservation.DispVisit,
                    MDIs = MDIs,
                    FirstMainDiag = firstMainDiag,
                    SecondMainDiag = secondMainDiag,
                    Anamnesa = dispObservation.Anamnesa,
                    HState = dispObservation.HState,
                    Therapy = dispObservation.Therapy,
                    Sign = dispObservation.Sign,
                    NZOKPay = dispObservation.NZOKPay
                };
            });
        }

        public async Task<List<DispObservationPreviewViewModel>> GetDispObservationsAsync(
            IWhereBuilder<DispObservation> dispObservationBuilder, 
            IHelperBuilder<DispObservation> helperBuilder, 
            int startIndex)
        {
            if (dispObservationBuilder == default)
            {
                throw new ArgumentNullException(nameof(dispObservationBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(dispObservationBuilder.Where(MedicContext.DispObservations.Skip(startIndex)))
                .ProjectTo<DispObservationPreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetDispObservationsCountAsync(IWhereBuilder<DispObservation> dispObservationBuilder)
        {
            if (dispObservationBuilder == default)
            {
                throw new ArgumentNullException(nameof(dispObservationBuilder));
            }

            return await dispObservationBuilder.Where(MedicContext.DispObservations)
                .CountAsync();
        }
    }
}
