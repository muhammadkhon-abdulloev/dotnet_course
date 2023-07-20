using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Interfaces;
using UrlShortener.Models;

namespace UrlShortener.Repository;

public class UrlRepository: IUrlRepository
{
    private readonly ApplicationContext _db;

    public UrlRepository(ApplicationContext db)
    {
        _db = db;
    }
    
    public async Task<Url?> GetLongUrl(string shortUrl)
    {
        var result = await _db.Urls.FirstOrDefaultAsync(u => u.ShortUrl == shortUrl);

        return result;
    }

    public async Task<Url?> GetShortUrl(string longUrl)
    {
        var result = await _db.Urls.FirstOrDefaultAsync(u => u.LongUrl == longUrl);

        return result;
    }
    

    public async Task<bool> InsertUrl(Url url)
    {
        var result = await _db.Urls.FirstOrDefaultAsync(u => u.ShortUrl == url.ShortUrl);
        if (result != null)
        {
            return false;
        }

        await _db.Urls.AddAsync(url);
        return true;
    }
}