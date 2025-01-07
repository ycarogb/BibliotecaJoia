using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dtos;
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

    public IActionResult Edit(string? id)
    {
        if (id == null)
            return NotFound();
        var livro = _livroService.ObterPorId(id);
        if (livro == null)
            return NotFound();

        return View(livro);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit([Bind("Nome, Autor, Editora, Id")] LivroDto livro)
    {
        if (livro.Id == null)
            return NotFound();
        try
        {
            _livroService.EditarLivro(livro);
            return RedirectToAction("List");
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public IActionResult Details(string? id)
    {
        if (id == null)
            return NotFound();
        var livro = _livroService.ObterPorId(id);
        if (livro == null)
            return NotFound();

        return View(livro);
    }

    public IActionResult Delete(string? id)
    {
        if (id == null)
            return NotFound();

        var livro = _livroService.ObterPorId(id);
        if (livro == null)
            return NotFound();
        
        return View(livro);
    }

    public IActionResult Create()
    {
        try
        {
            return View();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }   
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Nome, Autor, Editora")]LivroDto livro)
    {
        try
        {
            livro.IdStatusLivro = 1; //TODO Resolve o problema de criação de livro sem setar status - isso será alterado no futuro!!
            _livroService.Cadastrar(livro);
            return RedirectToAction("List");
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [HttpPost]
    public IActionResult Delete([Bind("Id, Nome, Autor, Editora")] LivroDto livro)
    {
        try
        {
            _livroService.Excluir(livro.Id);
            return RedirectToAction("List");
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}