using Microsoft.Extensions.Caching.Memory;

namespace DeveloperCodingTest.HackerRankApi.Cache;

public class InMemoryCacheService(IMemoryCache cache) : ICacheService
{
    public T? Get<T>(string key)
    {
        return cache.TryGetValue(key, out T? value) ? value : default;
    }

    public void Set<T>(string key, T value, TimeSpan expiration)
    {
        cache.Set(key, value, expiration);
    }
}