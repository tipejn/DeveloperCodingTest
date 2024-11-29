namespace DeveloperCodingTest.HackerRankApi.Contract;

public record StoryDto(
    string Title,
    string Uri,
    string PostedBy,
    string Time,
    int Score,
    int CommentCount
);