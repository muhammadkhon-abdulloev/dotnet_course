using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("/")]
public class MainController: ControllerBase
{
    public MainController() {}

    [HttpGet]
    public async Task IndexHandler()
    {
        Response.ContentType = "text/html; charset=utf-8";
        await Response.SendFileAsync("wwwroot/index.html");
    }
}