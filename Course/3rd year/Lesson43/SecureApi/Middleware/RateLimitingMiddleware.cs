using System.Net;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace SecureApi.Middlewares;


public class RateLimitingMiddleware
{
    private readonly RequestDelegate  _next;
    private readonly IMemoryCache _cache;
    private readonly RateLimitSettings _settings;
    private static readonly SemaphoreSlim _semaphore = new(1, 1);

    public RateLimitingMiddleware(
        RequestDelegate next,
        IMemoryCache cache,
        IOptions<RateLimitSettings> settings)
    {
        _next = next;
        _cache = cache;
        _settings = settings.Value;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var ip = context.Connection.RemoteIpAddress?.ToString();

        if (string.IsNullOrEmpty(ip))
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadGateway;
            await context.Response.WriteAsync("IP-address is not defined");
            return;
        }

        var cacheKey = $"{ip}_requests";
        await _semaphore.WaitAsync();

        try
        {
            if (!_cache.TryGetValue(cacheKey, out RequestTracker tracker))
            {
                tracker = new RequestTracker {Count = 1, FirstRequest =DateTime.UtcNow};
            }
            else
            {
                tracker.Count++;
                if (tracker.Count > _settings.Limit)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    await context.Response.WriteAsync("Too many requests");
                    return;
                }
            }
            _cache.Set(cacheKey, tracker, _settings.Period);
        }
        finally
        {
            _semaphore.Release();
        }

        await _next(context);
    }


}


public class RateLimitSettings
{
    public int Limit { get; set; }
    public TimeSpan Period { get; set; }
}

public class RequestTracker
{
    public int Count { get; set; }
    public DateTime FirstRequest { get; set; }
}