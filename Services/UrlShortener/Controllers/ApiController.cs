using Microsoft.AspNetCore.Mvc;
using UrlShortener.Dto;
using UrlShortener.Interfaces;

namespace UrlShortener.Controllers;

[ApiController]
[Route("/api/v{version:apiVersion}/l")]
[ApiVersion("1.0")]
public class ApiController: ControllerBase
{
    private readonly IUrlService _urlService;

    public ApiController(IUrlService urlService)
    {
        _urlService = urlService;
    }

    [HttpGet("{shortUrl}")] 
    [ProducesResponseType(200, Type = typeof(UrlDto)), 
     ProducesResponseType(404)]
    public IResult GetLongUrl(string shortUrl)
    {
        var url = _urlService.GetLongUrl(shortUrl);
        return url == "" ?  Results.NotFound() : Results.Json(new UrlDto{Url = url});
    }
    
    [HttpPost("short")] 
    [ProducesResponseType(200, Type = typeof(UrlDto)), 
     ProducesResponseType(400)]
    public IResult ShortUrl(UrlDto urlDto)
    {
        var shortUrl = _urlService.ShortUrl(urlDto.Url);
        return shortUrl == "" ?  Results.BadRequest() : Results.Json(new UrlDto{Url = shortUrl});
    }
}