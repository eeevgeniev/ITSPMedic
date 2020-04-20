using Medic.AppModels.HospitalPractices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IHospitalPracticeService
    {
        Task<List<HospitalPracticeSummaryViewModel>> GetSummaryAsync();

        Task<List<HospitalPracticeSummaryViewModel>> GetSummaryByMonthAsync();
    }
}