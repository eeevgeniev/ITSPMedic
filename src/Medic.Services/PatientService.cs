using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.Patients;
using Medic.AppModels.Sexes;
using Medic.Contexts;
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
        private readonly MedicContext MedicContext;
        private readonly MapperConfiguration Configuration;

        public PatientService(MedicContext medicContext, MapperConfiguration configuration)
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

            return await MedicContext.Patients
                .Include(p => p.Sex)
                .Include(p => p.Ins)
                    .ThenInclude(i => i.SendDiagnose)
                        .ThenInclude(d => d.Primary)
                .Include(p => p.InClinicProcedures)
                    .ThenInclude(p => p.FirstMainDiag)
                        .ThenInclude(d => d.MKB)
                .Include(p => p.Outs)
                    .ThenInclude(o => o.OutMainDiagnose)
                        .ThenInclude(d => d.Primary)
                .Include(p => p.PathProcedures)
                    .ThenInclude(pp => pp.FirstMainDiag)
                        .ThenInclude(d => d.MKB)
                .Include(p => p.ProtocolDrugTherapies)
                    .ThenInclude(p => p.Diag)
                        .ThenInclude(d => d.MKB)
                .Include(p => p.CommissionAprs)
                    .ThenInclude(ca => ca.MainDiag)
                        .ThenInclude(d => d.MKB)
                .Include(p => p.DispObservations)
                    .ThenInclude(obs => obs.FirstMainDiag)
                        .ThenInclude(d => d.MKB)
                .Include(p => p.PlannedProcedures)
                    .ThenInclude(pp => pp.Diagnose)
                        .ThenInclude(d => d.Primary)
                .ProjectTo<PatientViewModel>(Configuration)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PatientPreviewViewModel>> GetPatientsByQueryAsync(PatientSearch patientSearch, int startIndex, int length)
        {
            IQueryable<Patient> patientsQueryable = GetQueryable(MedicContext.Patients, patientSearch);

            return await patientsQueryable
                .ProjectTo<PatientPreviewViewModel>(Configuration)
                .Skip(startIndex)
                .Take(length)
                .ToListAsync();
        }

        public async Task<int> GetPatientsCountAsync(PatientSearch patientSearch)
        {
            IQueryable<Patient> patientsQueryable = GetQueryable(MedicContext.Patients, patientSearch);

            return await patientsQueryable.CountAsync();
        }

        public async Task<List<SexOption>> GetSexOptionsAsync()
        {
            return await MedicContext.Sexes
                .ProjectTo<SexOption>(Configuration)
                .ToListAsync();
        }

        private IQueryable<Patient> GetQueryable(IQueryable<Patient> patientsQueryable, PatientSearch patientSearch)
        {
            if (patientSearch != default)
            {
                if (!string.IsNullOrWhiteSpace(patientSearch.IdentityNumber))
                {
                    patientsQueryable = patientsQueryable.Where(p => EF.Functions.Like(p.IdentityNumber, patientSearch.IdentityNumber));
                }

                if (!string.IsNullOrWhiteSpace(patientSearch.FirstName))
                {
                    patientsQueryable = patientsQueryable.Where(p => EF.Functions.Like(p.FirstName, $"{patientSearch.FirstName}%"));
                }

                if (!string.IsNullOrWhiteSpace(patientSearch.SecondName))
                {
                    patientsQueryable = patientsQueryable.Where(p => EF.Functions.Like(p.SecondName, $"{patientSearch.SecondName}%"));
                }

                if (!string.IsNullOrWhiteSpace(patientSearch.LastName))
                {
                    patientsQueryable = patientsQueryable.Where(p => EF.Functions.Like(p.LastName, $"{patientSearch.LastName}%"));
                }

                if (patientSearch.BirthDate != null && patientSearch.BirthDate != default)
                {
                    patientsQueryable = patientsQueryable.Where(p => p.BirthDate == patientSearch.BirthDate);
                }
            }

            return patientsQueryable;
        }
    }
}