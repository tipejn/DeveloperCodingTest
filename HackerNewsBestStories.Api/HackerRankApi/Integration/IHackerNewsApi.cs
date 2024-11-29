using Refit;

namespace HackerNewsBestStories.Api.HackerRankApi.Integration;

public interface IHackerNewsApi
{
    [Get("/beststories.json")]
    Task<List<int>?> GetBestStoryIdsAsync();

    [Get("/item/{storyId}.json")]
    Task<StoryDetailsDto?> GetStoryDetailsAsync(int storyId);
}