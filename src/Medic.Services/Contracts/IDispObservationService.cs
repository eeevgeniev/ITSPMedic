using Medic.AppModels.DispObservations;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IDispObservationService
    {
        Task<DispObservationViewModel> GetDispObservationAsync(int id);
    }
}
