using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.CommissionAprs;
using Medic.AppModels.DispObservations;
using Medic.AppModels.InClinicProcedures;
using Medic.AppModels.Ins;
using Medic.AppModels.Outs;
using Medic.AppModels.PathProcedures;
using Medic.AppModels.Patients;
using Medic.AppModels.Plannings;
using Medic.AppModels.ProtocolDrugTherapies;
using Medic.AppModels.Sexes;
using Medic.Contexts.Contracts;
using Medic.Entities;
using Medic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public PatientService(IMedicContext medicContext, MapperConfiguration configuration)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<PatientViewModel> GetPatientAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            return await Task<PatientViewModel>.Run(() =>
            {
                Patient patient = MedicContext.Patients
                .Include(p => p.Sex)
                .SingleOrDefault(p => p.Id == id);

                if (patient == default)
                {
                    return default;
                }

                ICollection<PatientInPreviewViewModel> patientInPreviewViewModel = MedicContext.Ins
                    .Where(i => i.PatientId == id)
                    .ProjectTo<PatientInPreviewViewModel>(Configuration)
                    .ToList();

                ICollection<PatientInClinicProcedurePreviewViewModel> patientInClinicProcedures = MedicContext.InClinicProcedures
                    .Where(icp => icp.PatientId == id)
                    .ProjectTo<PatientInClinicProcedurePreviewViewModel>(Configuration)
                    .ToList();

                ICollection<PatientOutPreviewViewModel> patientOuts = MedicContext.Outs
                    .Where(o => o.PatientId == id)
                    .ProjectTo<PatientOutPreviewViewModel>(Configuration)
                    .ToList();

                ICollection<PatientPathProcedurePreviewViewModel> patientPathProcedures = MedicContext.PathProcedures
                    .Where(pp => pp.PatientId == id)
                    .ProjectTo<PatientPathProcedurePreviewViewModel>(Configuration)
                    .ToList();

                ICollection<PatientProtocolDrugTherapyPreviewViewModel> patientProtocolDrugTherapies = MedicContext.ProtocolDrugTherapies
                    .Where(pdt => pdt.PatientId == id)
                    .ProjectTo<PatientProtocolDrugTherapyPreviewViewModel>(Configuration)
                    .ToList();

                ICollection<PatientCommissionAprPreviewViewModel> patientCommissionAprs = MedicContext.CommissionAprs
                    .Where(ca => ca.PatientId == id)
                    .ProjectTo<PatientCommissionAprPreviewViewModel>(Configuration)
                    .ToList();

                ICollection<PatientDispObservationPreviewViewModel> patientDispObservations = MedicContext.DispObservations
                    .Where(disp => disp.PatientId == id)
                    .ProjectTo<PatientDispObservationPreviewViewModel>(Configuration)
                    .ToList();

                ICollection<PatientPlannedPreviewViewModel> patientPlannings = MedicContext.Plannings
                    .Where(p => p.PatientId == id)
                    .ProjectTo<PatientPlannedPreviewViewModel>(Configuration)
                    .ToList();

                return new PatientViewModel()
                {
                    Id = patient.Id,
                    IdentityNumber = patient.IdentityNumber,
                    BirthDate = patient.BirthDate,
                    FirstName = patient.FirstName,
                    SecondName = patient.SecondName,
                    LastName = patient.LastName,
                    Sex = patient.Sex.Name,
                    Address = patient.Address,
                    Notes = patient.Notes,
                    Ins = patientInPreviewViewModel,
                    InClinicProcedures = patientInClinicProcedures,
                    Outs = patientOuts,
                    PathProcedures = patientPathProcedures,
                    ProtocolDrugTherapies = patientProtocolDrugTherapies,
                    CommissionAprs = patientCommissionAprs,
                    DispObservations = patientDispObservations,
                    Plannings = patientPlannings,
                };
            });
        }

        public async Task<List<PatientPreviewViewModel>> GetPatientsByQueryAsync(
            IWhereBuilder<Patient> patientBuilder,
            IHelperBuilder<Patient> helperBuilder,
            int startIndex)
        {
            if (patientBuilder == default)
            {
                throw new ArgumentNullException(nameof(patientBuilder));
            }

            if (helperBuilder == default)
            {
                throw new ArgumentNullException(nameof(helperBuilder));
            }

            return await helperBuilder.BuildQuery(patientBuilder.Where(MedicContext.Patients).Skip(startIndex))
                .ProjectTo<PatientPreviewViewModel>(Configuration)
                .ToListAsync();
        }

        public async Task<int> GetPatientsCountAsync(IWhereBuilder<Patient> patientBuilder)
        {
            if (patientBuilder == default)
            {
                throw new ArgumentNullException(nameof(patientBuilder));
            }

            return await patientBuilder
                .Where(MedicContext.Patients)
                .CountAsync();
        }

        public async Task<List<SexOption>> GetSexOptionsAsync()
        {
            return await MedicContext.Sexes
                .ProjectTo<SexOption>(Configuration)
                .ToListAsync();
        }
    }
}