using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.AppModels.Patients;
using Medic.AppModels.Sexes;
using Medic.Contexts;
using Medic.Entities;
using Medic.Services.Contracts;
using Medic.Services.Helpers;
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
                DateTimeHelper dateTimeHelper = new DateTimeHelper();

                if (!string.IsNullOrWhiteSpace(patientSearch.IdentityNumber))
                {
                    patientsQueryable = patientsQueryable.Where(p => EF.Functions.Like(p.IdentityNumber, patientSearch.IdentityNumber));
                }

                if (patientSearch.Age != default)
                {
                    (DateTime startDate, DateTime endDate) = dateTimeHelper.CalculateYearsBoundsByAges((int)patientSearch.Age);

                    patientsQueryable = patientsQueryable.Where(p => startDate < p.BirthDate && p.BirthDate <= endDate);
                }

                if (patientSearch.Age == default && patientSearch.OlderThan != default)
                {
                    patientsQueryable = patientsQueryable.Where(p => p.BirthDate <= dateTimeHelper.CalculateYearBoundByAge((int)patientSearch.OlderThan));
                }

                if (patientSearch.Age == default && patientSearch.YoungerThan != default)
                {
                    patientsQueryable = patientsQueryable.Where(p => p.BirthDate >= dateTimeHelper.CalculateYearBoundByAge((int)patientSearch.YoungerThan));
                }

                if (patientSearch.Sex != default)
                {
                    int sex = (int)patientSearch.Sex;

                    patientsQueryable = patientsQueryable.Where(p => p.Sex.Id == sex);
                }
            }

            return patientsQueryable;
        }
    }
}