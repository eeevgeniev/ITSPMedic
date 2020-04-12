using Microsoft.EntityFrameworkCore;

namespace Medic.Entities.Contracts
{
    public interface IModelBuilder
    {
        void CreateRules(ModelBuilder builder);
    }
}