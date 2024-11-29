using HackerNewsBestStories.Api.HackerRankApi.Cache;
using HackerNewsBestStories.Api.HackerRankApi.Contract;
using HackerNewsBestStories.Api.HackerRankApi.Integration;
using MediatR;
using Microsoft.Extensions.Options;

namespace HackerNewsBestStories.Api.HackerRankApi.Services;

public class GetBestStoriesQueryHandler(
    ICacheManager cacheManager,
    IHackerNewsApi hackerNewsApi,
    ILogger<GetBestStoriesQueryHandler> logger,
    IOptions<CacheSettings> cacheSettings)
    : IRequestHandler<GetBestStoriesQuery, List<StoryDto>>
{
    private readonly int _cacheTtlMinutes = cacheSettings.Value.CacheTTLMinutes;

    public async Task<List<StoryDto>> Handle(GetBestStoriesQuery request, CancellationToken cancellationToken)
    {
        if (request.Count <= 0)
        {
            return [];
        }

        var storyIds = await cacheManager.GetOrFetchStoryIdsAsync(
            hackerNewsApi.GetBestStoryIdsAsync,
            _cacheTtlMinutes) ?? [];

        if (storyIds.Count == 0)
        {
            logger.LogWarning("No stories found");
        }

        var tasks = storyIds
            .Take(request.Count)
            .Select(storyId =>
                cacheManager.GetOrFetchStoryDetailsAsync(
                    storyId,
                    () => FetchAndMapStoryDetailsAsync(storyId),
                    _cacheTtlMinutes));

        var stories = await Task.WhenAll(tasks);

        return stories
            .Where(s => s is not null)
            .OrderByDescending(s => s.Score)
            .ToList();
    }

    private async Task<StoryDto?> FetchAndMapStoryDetailsAsync(int storyId)
    {
        var storyDetailsDto = await hackerNewsApi.GetStoryDetailsAsync(storyId);

        if (storyDetailsDto is null)
        {
            logger.LogWarning("Story {storyId} does not exist", storyId);
            return null;
        }
        
        return StoryMapper.Map(storyDetailsDto);
    }
}