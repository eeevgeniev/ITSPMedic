using Medic.AppModels.CommissionAprs;
using Medic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface ICommissionAprService
    {
        Task<CommissionAprViewModel> GetCommissionAprAsync(int id);

        Task<List<CommissionAprPreviewViewModel>> GetCommissionAprsAsync(
            IWhereBuilder<CommissionApr> commissionAprWhereBuilder,
            IHelperBuilder<CommissionApr> helperBuilder,
            int startIndex);

        Task<int> GetCommissionAprsCountAsync(IWhereBuilder<CommissionApr> commissionAprWhereBuilder);
    }
}
