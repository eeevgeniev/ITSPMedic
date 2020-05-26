using Medic.AppModels.Patients;
using Medic.AppModels.Sexes;
using Medic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IPatientService
    {
        Task<PatientViewModel> GetPatientAsync(int id);

        Task<List<PatientPreviewViewModel>> GetPatientsByQueryAsync(
            IWhereBuilder<Patient> patientBuilder, 
            IHelperBuilder<Patient> helperBuilder, 
            int startIndex);

        Task<int> GetPatientsCountAsync(IWhereBuilder<Patient> patientBuilder);

        Task<List<SexOption>> GetSexOptionsAsync();
    }
}