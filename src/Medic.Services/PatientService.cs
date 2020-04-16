using Medic.Contexts;
using Medic.Entities;
using Medic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Services
{
    public class PatientService : IPatientService
    {
        private readonly MedicContext MedicContext;

        public PatientService(MedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
        }

        public async Task<Patient> GetPatientAsync(int index)
        {
            if (index < 1)
            {
                throw new ArgumentException(nameof(index));
            }

            return await Task<Patient>.Run(() => MedicContext.Patients.Find(index));
        }

        public async Task<List<Patient>> GetPatientsAsync(int startIndex = 0, int length = 10)
        {
            if (startIndex < 0)
            {
                throw new ArgumentException(nameof(startIndex));
            }

            return await Task<List<Patient>>.Run(() =>
              {
                  return MedicContext.Patients
                      .Skip(startIndex)
                      .Take(length)
                      .ToList();
              });
        }

        public async Task<int> GetPatientsCountAsync()
        {
            return await Task<int>.Run(() => MedicContext.Patients.Count());
        }
    }
}
