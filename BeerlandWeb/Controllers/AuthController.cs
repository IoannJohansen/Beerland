using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Controllers;

[Route("auth")]
public class AuthController : Controller
{
    public AuthController()
    {
        
    }

    [Route("index")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}