using Medic.AppModels.Ins;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IInService
    {
        public Task<List<InPreviewViewModel>> GetInsAsync(InsSerach search, int startIndex, int count);

        public Task<int> GetInsCountAsync(InsSerach search);
    }
}
