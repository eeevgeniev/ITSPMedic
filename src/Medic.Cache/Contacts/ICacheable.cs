namespace Medic.Cache.Contacts
{
    public interface ICacheable
    {
        bool TryGetValue<T>(string key, out T value);

        void Set(string key, object value);

        void Clear();
    }
}