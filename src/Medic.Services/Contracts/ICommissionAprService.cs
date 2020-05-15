using Medic.AppModels.CommissionAprs;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface ICommissionAprService
    {
        Task<CommissionAprViewModel> GetCommissionAprAsync(int id);
    }
}
