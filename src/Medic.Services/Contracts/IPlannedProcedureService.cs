using Medic.AppModels.PlannedProcedures;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IPlannedProcedureService
    {
        Task<PlannedProcedureViewModel> GetPlannedProcedureAsync(int id);
    }
}
