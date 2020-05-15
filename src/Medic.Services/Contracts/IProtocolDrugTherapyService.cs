using Medic.AppModels.ProtocolDrugTherapies;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IProtocolDrugTherapyService
    {
        Task<ProtocolDrugTherapyViewModel> GetProtocolDrugTherapyAsync(int id);
    }
}
