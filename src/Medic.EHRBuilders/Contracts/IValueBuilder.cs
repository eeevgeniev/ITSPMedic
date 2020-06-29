namespace Medic.EHRBuilders.Contracts
{
    public interface IValueBuilder<T> : IDataValueBuilder where T : struct
    {
        IValueBuilder<T> AddValue(T value);

        IValueBuilder<T> Clear();
    }
}
