using Medic.AppModels.Ins;
using Medic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IInService
    {
        Task<List<InPreviewViewModel>> GetInsAsync(IWhereBuilder<In> inBuilder, IHelperBuilder<In> helperBuilder, int startIndex);

        Task<int> GetInsCountAsync(IWhereBuilder<In> inBuilder);

        Task<InViewModel> GetInAsync(int id);
    }
}
