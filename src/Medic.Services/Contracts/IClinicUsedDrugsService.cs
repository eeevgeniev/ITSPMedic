using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IClinicUsedDrugsService
    {
        Task<List<string>> GetDrugCodesAsync();
    }
}
