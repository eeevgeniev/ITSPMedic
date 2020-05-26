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
                .ProjectTo<PatientViewModel>(Configuration)
                .SingleOrDefaultAsync(p => p.Id == id);
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