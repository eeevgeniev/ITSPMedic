using Medic.AppModels.InClinicProcedures;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IInClinicProcedureService
    {
        Task<InClinicProcedureViewModel> GetInClinicProcedureAsync(int id);
    }
}
