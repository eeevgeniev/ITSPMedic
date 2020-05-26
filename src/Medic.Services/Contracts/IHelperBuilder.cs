using System.Linq;

namespace Medic.Services.Contracts
{
    public interface IHelperBuilder<T>
    {
        IQueryable<T> BuildQuery(IQueryable<T> query);
    }
}
