using System;
using System.Runtime.Caching;

namespace DevaxiloS.Infras.Caching
{
    public class DevaxiloMemoryCache
    {
        public static object GetValue(string key)
        {
            return MemoryCache.Default.Get(key);
        }

        public static bool Add(string key, object value, DateTimeOffset absExpiration)
        {
            return MemoryCache.Default.Add(key, value, absExpiration);
        }

        public static void Delete(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }
        }
    }
}
