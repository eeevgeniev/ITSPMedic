using Medic.AppModels.DispObservations;
using Medic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IDispObservationService
    {
        Task<DispObservationViewModel> GetDispObservationAsync(int id);

        Task<List<DispObservationPreviewViewModel>> GetDispObservationsAsync(
            IWhereBuilder<DispObservation> dispObservationBuilder,
            IHelperBuilder<DispObservation> helperBuilder,
            int startIndex);

        Task<int> GetDispObservationsCountAsync(IWhereBuilder<DispObservation> dispObservationBuilder);
    }
}
