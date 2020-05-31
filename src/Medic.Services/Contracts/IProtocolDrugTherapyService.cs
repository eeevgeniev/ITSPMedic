using Medic.AppModels.ProtocolDrugTherapies;
using Medic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IProtocolDrugTherapyService
    {
        Task<ProtocolDrugTherapyViewModel> GetProtocolDrugTherapyAsync(int id);

        Task<List<ProtocolDrugTherapyPreviewViewModel>> GetProtocolDrugTherapiesAsync(
            IWhereBuilder<ProtocolDrugTherapy> protocolDrugTherapyBuilder, 
            IHelperBuilder<ProtocolDrugTherapy> helperBuilder, 
            int startIndex);

        Task<int> GetProtocolDrugTherapiesCountAsync(IWhereBuilder<ProtocolDrugTherapy> protocolDrugTherapyBuilder);
    }
}
