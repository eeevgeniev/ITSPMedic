namespace Medic.Mappers.Contracts
{
    public interface IMappable
    {
        TResult Map<TResult, TSource>(TSource source);
    }
}
