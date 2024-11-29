using HackerNewsBestStories.Api.HackerRankApi.Contract;

namespace HackerNewsBestStories.Api.HackerRankApi.Services;

public interface ICacheManager
{
    Task<List<int>?> GetOrFetchStoryIdsAsync(Func<Task<List<int>?>> fetchFunc, int cacheTtlMinutes);
    Task<StoryDto?> GetOrFetchStoryDetailsAsync(int storyId, Func<Task<StoryDto?>> fetchFunc, int cacheTtlMinutes);
}
