using Medic.AppModels.HealthRegions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.Services.Contracts
{
    public interface IHealthRegionService
    {
        Task<List<HealthRegionOption>> GetHealthRegionsAsync();
    }
}
