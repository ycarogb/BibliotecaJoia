using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Interfaces.Services;

namespace WebApp.Controllers;

public class LivroController : Controller
{
    private readonly ILivroService _livroService;

    public LivroController(ILivroService livroService)
    {
        _livroService = livroService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult List()
    {
        try
        {
            var livros = _livroService.Listar();
            return View(livros);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}