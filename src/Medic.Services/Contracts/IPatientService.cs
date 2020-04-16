using Medic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IPatientService
    {
        public Task<List<Patient>> GetPatientsAsync(int startIndex = 0, int length = 10);

        public Task<int> GetPatientsCountAsync();

        public Task<Patient> GetPatientAsync(int index);
    }
}