using System.Security.Cryptography;
using UrlShortener.Helpers;
using UrlShortener.Interfaces;
using UrlShortener.Models;

namespace UrlShortener.Services;

public class UrlService: IUrlService
{
    private readonly IUrlRepository _repository;
    private readonly ICacheRepository _cacheRepository;
    private readonly string _baseUrl;

    public UrlService(
        IConfiguration configuration,  
        ICacheRepository cacheRepository, 
        IUrlRepository repository
        )
    {
        _baseUrl = configuration["BaseUrl"]!;
        _cacheRepository = cacheRepository;
        _repository = repository;
    }

    public string GetLongUrl(string shortUrl)
    {
        var url = _repository.GetLongUrl(shortUrl).Result;
        if (url == null || url.ShortUrl != shortUrl)
        {
            return "";
        }
        
        if (url.LongUrl!.StartsWith("http://") || url.LongUrl!.StartsWith("https://"))
        {
            return url.LongUrl;
        }

        
        return $"https://{url.LongUrl}";
    }

    public string ShortUrl(string longUrl)
    {
        while (true)
        {
            var shortUrl = UrlShortenerHelper.GenerateNewShort(RandomNumberGenerator.GetInt32(0, 999999));
            var url = new Url() { LongUrl = longUrl, ShortUrl = shortUrl };

            var ok = _repository.InsertUrl(url);
            if (!ok.Result)
            {
                continue;
            }

            _cacheRepository.InsertUrl(url);

            return $"{_baseUrl}{shortUrl}";
        }
    }
}