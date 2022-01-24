using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Controllers;

[Route("home")]
public class HomeController : Controller
{
    public HomeController()
    {
        
    }
    
    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }
    
}