using DeveloperCodingTest.HackerRankApi.Cache;
using DeveloperCodingTest.HackerRankApi.Integration;
using DeveloperCodingTest.HackerRankApi.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add IMemoryCache to the DI container
builder.Services.AddMemoryCache();

// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Register other services
builder.Services.Configure<CacheSettings>(
    builder.Configuration.GetSection("CacheSettings"));
builder.Services.AddScoped<ICacheService, InMemoryCacheService>();
builder.Services.AddScoped<ICacheManager, CacheManager>();

builder.Services.AddRefitClient<IHackerNewsApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/");
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();