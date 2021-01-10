using Medic.AppModels.Transfers;
using Medic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface ITransferService
    {
        Task<List<TransferPreviewViewModel>> GetTrasnfersAsync(IWhereBuilder<Transfer> transferBuilder, IHelperBuilder<Transfer> helperBuilder, int startIndex);

        Task<int> GetTrasnfersCountAsync(IWhereBuilder<Transfer> transferBuilder);

        Task<TransferViewModel> GetTrasnferAsync(int id);
    }
}
