using Medic.AppModels.CPFiles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface ICPFileService
    {
        Task<List<CPFileSummaryViewModel>> GetSummary();
    }
}