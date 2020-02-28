using Microsoft.Extensions.Caching.Memory;

namespace WebApiCodingChallenge.Services.Wrappers
{
    public interface IMemoryCacheWrapper
    {
        TItem Set<TItem>(object cacheKey, TItem value);
        bool TryGetValue<TItem>(object key, out TItem value);
    }

    public class MemoryCacheWrapper : IMemoryCacheWrapper
    {
        private IMemoryCache _memoryCache;

        public MemoryCacheWrapper(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public TItem Set<TItem>(object cacheKey, TItem value)
        {
            return _memoryCache.Set(cacheKey, value);
        }

        public bool TryGetValue<TItem>(object key, out TItem value)
        {
            return _memoryCache.TryGetValue(key, out value);
        }
    }
}
