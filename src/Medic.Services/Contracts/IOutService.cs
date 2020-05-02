using Medic.AppModels.Outs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IOutService
    {
        Task<List<OutPreviewViewModel>> GetOutsAsync(OutSearch search, int startIndex, int count);

        Task<int> GetOutsCountAsync(OutSearch search);

        Task<OutViewModel> GetOutAsyns(int id);
    }
}