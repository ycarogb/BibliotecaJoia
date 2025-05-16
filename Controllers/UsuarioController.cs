using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dtos;
using WebApp.Models.Interfaces.Services;

namespace WebApp.Controllers;

public class UsuarioController: Controller
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult List()
    {
        try
        {
            var usuarios = _usuarioService.Listar();
            return View(usuarios);
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
        var usuario = _usuarioService.ObterPorId(id);
        if (usuario == null)
            return NotFound();

        return View(usuario);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit([Bind("Nome, Autor, Editora, Id")] UsuarioDto usuario)
    {
        if (usuario.Id == null)
            return NotFound();
        try
        {
            _usuarioService.Editar(usuario);
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
        var usuario = _usuarioService.ObterPorId(id);
        if (usuario == null)
            return NotFound();

        return View(usuario);
    }

    public IActionResult Delete(string? id)
    {
        if (id == null)
            return NotFound();

        var usuario = _usuarioService.ObterPorId(id);
        if (usuario == null)
            return NotFound();
        
        return View(usuario);
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
    public IActionResult Create([Bind("Nome, Autor, Editora")]UsuarioDto usuario)
    {
        try
        {
            _usuarioService.Cadastrar(usuario);
            return RedirectToAction("List");
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [HttpPost]
    public IActionResult Delete([Bind("Id, Nome, Autor, Editora")] UsuarioDto usuario)
    {
        try
        {
            _usuarioService.Excluir(usuario.Id);
            return RedirectToAction("List");
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}