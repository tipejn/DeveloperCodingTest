namespace HackerNewsBestStories.Api.HackerRankApi.Integration;

public record StoryDetailsDto(
    string By,
    int Descendants,
    int Id,
    List<int> Kids,
    int Score,
    long Time,
    string Title,
    string Type,
    string Url
);
