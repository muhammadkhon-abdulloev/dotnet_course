using UrlShortener.Models;

namespace UrlShortener.Interfaces;

public interface IUrlRepository
{
    Task<Url?> GetLongUrl(string shortUrl);
    Task<bool> InsertUrl(Url url);
}