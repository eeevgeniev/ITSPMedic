using Medic.AppModels.Ins;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IInService
    {
        Task<List<InPreviewViewModel>> GetInsAsync(InsSerach search, int startIndex, int count);

        Task<int> GetInsCountAsync(InsSerach search);

        Task<InViewModel> GetInAsync(int id);
    }
}
