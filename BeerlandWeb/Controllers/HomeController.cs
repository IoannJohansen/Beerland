using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Controllers;

[Route("home")]
public class HomeController : Controller
{
    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }
}