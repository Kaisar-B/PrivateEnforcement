using Microsoft.Extensions.Caching.Memory;

namespace KIT.Cache
{
    /// <summary>
    ///     Specific implementation of cache.
    ///     Memory based cache
    /// </summary>
    public static class CacheProvider 
    {
        public static bool Contains(string key)
        {
            throw new NotImplementedException();
        }

        public static TResult Get<TResult>(string key)
        {
            throw new NotImplementedException();
        }

        public static void Set<TResult>(string key, TResult value)
        {
            throw new NotImplementedException();
        }

        public static void Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
