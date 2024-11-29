using HackerNewsBestStories.Api.HackerRankApi.Cache;
using HackerNewsBestStories.Api.HackerRankApi.Contract;

namespace HackerNewsBestStories.Api.HackerRankApi.Services;

public class CacheManager(ICacheService cacheService) : ICacheManager
{
    public async Task<List<int>?> GetOrFetchStoryIdsAsync(Func<Task<List<int>?>> fetchFunc, int cacheTtlMinutes)
    {
        return await GetOrFetchAsync("BestStoryIds", fetchFunc, cacheTtlMinutes);
    }

    public async Task<StoryDto?> GetOrFetchStoryDetailsAsync(int storyId, Func<Task<StoryDto?>> fetchFunc, int cacheTtlMinutes)
    {
        var cacheKey = $"StoryDetails:{storyId}";
        return await GetOrFetchAsync(cacheKey, fetchFunc, cacheTtlMinutes);
    }

    private async Task<T?> GetOrFetchAsync<T>(string cacheKey, Func<Task<T?>> fetchFunc, int cacheTtlMinutes) where T : class
    {
        var cachedData = cacheService.Get<T>(cacheKey);
        if (cachedData != null)
        {
            return cachedData;
        }

        var data = await fetchFunc();
        if (data != null)
        {
            cacheService.Set(cacheKey, data, TimeSpan.FromMinutes(cacheTtlMinutes));
        }

        return data;
    }
}