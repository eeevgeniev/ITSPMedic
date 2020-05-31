using Medic.AppModels.Diagnoses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IDiagnoseService
    {
        Task<List<DiagnoseMKBSummaryViewModel>> MKBSummaryAsync(int startIndex, int take);

        Task<int> GetMKBSummaryCountAsync();
    }
}
