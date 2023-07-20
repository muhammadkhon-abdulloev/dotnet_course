namespace UrlShortener.Interfaces;

public interface IUrlService
{
    public string GetLongUrl(string shortUrl);
    public string ShortUrl(string longUrl);
}