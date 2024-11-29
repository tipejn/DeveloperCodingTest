using DeveloperCodingTest.HackerRankApi.Contract;
using MediatR;

namespace DeveloperCodingTest.HackerRankApi.Services;

public record GetBestStoriesQuery(int Count) : IRequest<List<StoryDto>>;