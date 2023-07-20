using Microsoft.AspNetCore.Mvc;
using UrlShortener.Dto;
using UrlShortener.Interfaces;

namespace UrlShortener.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("v{version:apiVersion}/l")]
[ApiVersion("1.0")]

public class MainController: ControllerBase
{
    private readonly IUrlService _urlService;

    public MainController(IUrlService urlService)
    {
        _urlService = urlService;
    }

    [HttpGet("{shortUrl}")] 
    [ProducesResponseType(308), 
     ProducesResponseType(404)]
    public IResult GetLongUrl(string shortUrl)
    {
        var url = _urlService.GetLongUrl(shortUrl);
        return url == "" ?  Results.NotFound() : Results.Redirect(url);
    }
}