using UrlShortener.Models;

namespace UrlShortener.Interfaces;

public interface ICacheRepository
{
    Url? GetLongUrl(string shortUrl);
    void InsertUrl(Url url);
}