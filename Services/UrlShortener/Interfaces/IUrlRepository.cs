using UrlShortener.Models;

namespace UrlShortener.Interfaces;

public interface IUrlRepository
{
    Task<Url?> GetLongUrl(string shortUrl);
    Task<Url?> GetShortUrl(string longUrl);
    Task<bool> InsertUrl(Url url);
}