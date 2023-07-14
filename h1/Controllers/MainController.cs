using Microsoft.AspNetCore.Mvc;

namespace h1.Controllers;

[ApiController]
[Route("/")]
public class MainController: ControllerBase
{
    public MainController() {}

    [HttpGet]
    public async Task IndexHandler()
    {
        HttpContext.Response.ContentType = "text/html; charset=utf-8";
        await HttpContext.Response.SendFileAsync("html/index.html");
    }
}