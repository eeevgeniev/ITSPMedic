using Medic.AppModels.Diags;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IDiagService
    {
        Task<List<DiagMKBSummaryViewModel>> GetMKBSummaryAsync();
    }
}
