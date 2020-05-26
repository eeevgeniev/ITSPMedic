using System.Linq;

namespace Medic.Services.Contracts
{
    public interface IWhereBuilder<T>
    {
        IQueryable<T> Where(IQueryable<T> queryable);
    }
}