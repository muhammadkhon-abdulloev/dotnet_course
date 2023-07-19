using Microsoft.Extensions.Caching.Memory;
using UrlShortener.Interfaces;
using UrlShortener.Models;

namespace UrlShortener.Repository;

public class MemoryCacheRepository: ICacheRepository
{
    private readonly IMemoryCache _cache;

    public MemoryCacheRepository(IMemoryCache memoryCache)
    {
        _cache = memoryCache;
    }

    public Url? GetLongUrl(string shortUrl)
    {
        return _cache.TryGetValue(shortUrl, out var result) ? result as Url : null;
    }

    public void InsertUrl(Url url)
    {
        _cache.Set(url.ShortUrl!, url);
    }
}