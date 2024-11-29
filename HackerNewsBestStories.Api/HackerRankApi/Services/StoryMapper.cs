using HackerNewsBestStories.Api.HackerRankApi.Contract;
using HackerNewsBestStories.Api.HackerRankApi.Integration;

namespace HackerNewsBestStories.Api.HackerRankApi.Services;

public static class StoryMapper
{
    public static StoryDto Map(StoryDetailsDto storyDetailsDto)
    {
        return new StoryDto(
            Title: storyDetailsDto.Title,
            Uri: storyDetailsDto.Url,
            PostedBy: storyDetailsDto.By,
            Time: DateTimeOffset.FromUnixTimeSeconds(storyDetailsDto.Time).ToString("o"),
            Score: storyDetailsDto.Score,
            CommentCount: storyDetailsDto.Descendants
        );
    }
}