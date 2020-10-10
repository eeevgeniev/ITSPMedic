using Medic.AppModels.Outs;
using Medic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IOutService
    {
        Task<List<OutPreviewViewModel>> GetOutsAsync(
            IWhereBuilder<Out> outBuilder, 
            IHelperBuilder<Out> helperBuilder, 
            int startIndex);

        Task<int> GetOutsCountAsync(IWhereBuilder<Out> outBuilder);

        Task<OutViewModel> GetOutAsync(int id);
    }
}