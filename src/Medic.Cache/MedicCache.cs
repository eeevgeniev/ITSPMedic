using Medic.Cache.Contacts;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Medic.Cache
{
    public class MedicCache : ICacheable
    {
        private readonly MemoryCache MemoryCache;
        private readonly MemoryCacheEntryOptions Options;

        public MedicCache()
            : this(1024, 5) { }

        public MedicCache(int sizeLimit, int slidingExpiration)
        {
            MemoryCache = new MemoryCache(new MemoryCacheOptions()
            {
                SizeLimit = sizeLimit,
            });

            Options = new MemoryCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromMinutes(slidingExpiration > 0 ? slidingExpiration : throw new ArgumentException($"{nameof(slidingExpiration)} cannot be less than 0.")),
                Size = 1
            };
        }

        public void Clear() => MemoryCache.Compact(100);

        public void Set(string key, object value) => MemoryCache.Set(key, value, Options);

        public bool TryGetValue<T>(string key, out T value) => MemoryCache.TryGetValue(key, out value);
    }
}