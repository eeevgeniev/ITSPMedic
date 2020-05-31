using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IDrugProtocolService
    {
        public Task<List<string>> GetDrugProtocolATCNames();
    }
}
