using HackerNewsBestStories.Api.HackerRankApi.Contract;
using MediatR;

namespace HackerNewsBestStories.Api.HackerRankApi.Services;

public record GetBestStoriesQuery(int Count) : IRequest<List<StoryDto>>;