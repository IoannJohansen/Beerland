using Microsoft.AspNetCore.Mvc;

namespace BeerlandWeb.Controllers;

[Route("Error")]
public class ErrorController : Controller
{
    [HttpGet]
    [Route("error")]
    public IActionResult Error()
    {
        return View("ErrorView");
    }
}