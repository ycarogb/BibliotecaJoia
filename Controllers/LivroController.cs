using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class LivroController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}