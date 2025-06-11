using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dtos;
using WebApp.Models.Interfaces.Services;
using WebApp.Models.ViewsModels;

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
            var viewModel = new ListagemLivroViewModel()
            {
                Livros = livros,
                Administrador = User.IsInRole("Administrador"),
                Cliente = User.IsInRole("Cliente")
            };
            return View(viewModel);
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
            _livroService.Editar(livro);
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

    public IActionResult Emprestar(string? id)
    {
        try
        {
            if (id == null)
                return NotFound();

            var livro = _livroService.ObterPorId(id);
            if (livro == null)
                return NotFound();
        
            return View(livro);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }   
    }

    [HttpPost]
    public IActionResult Emprestar([Bind("Id, Nome, Autor, Editora")] LivroDto livro)
    {
        try
        {
            var idUsuario = User.Claims.First().Value;
            if (idUsuario == null) 
                throw new Exception("Usuário não encontrado. Procure a administração.");
            
            _livroService.Emprestar(livro, idUsuario);
            return RedirectToAction("List");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}