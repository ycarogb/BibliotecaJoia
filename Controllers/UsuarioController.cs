using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dtos;
using WebApp.Models.Entidades;
using WebApp.Models.Interfaces.Services;

namespace WebApp.Controllers;

public class UsuarioController: Controller
{
    private readonly IUsuarioService _usuarioService;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly UserManager<Usuario> _userManager;

    public UsuarioController(
        IUsuarioService usuarioService, 
        SignInManager<Usuario> signInManager, 
        UserManager<Usuario> userManager)
    {
        _usuarioService = usuarioService;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public IActionResult Login()
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

    public IActionResult Edit(int id)
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
    public IActionResult Edit([Bind("Id, Login, Senha")] UsuarioDto usuario)
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

    public IActionResult Details(int id)
    {
        if (id == null)
            return NotFound();
        var usuario = _usuarioService.ObterPorId(id);
        if (usuario == null)
            return NotFound();

        return View(usuario);
    }

    public IActionResult Delete(int id)
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
    public IActionResult Create([Bind("Id, Login, Senha")]UsuarioDto usuario)
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
    public IActionResult Delete([Bind("Id, Login, Senha")] UsuarioDto usuario)
    {
        try
        {
            _usuarioService.Excluir(int.Parse(usuario.Id));
            return RedirectToAction("List");
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(string login, string senha)
    {
        try
        {
            var usuarioEncontrado = await _userManager.FindByNameAsync(login);

            if (usuarioEncontrado == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário não encontrado!" );
                return Login();
            }

            var result = await _signInManager.PasswordSignInAsync(usuarioEncontrado, senha, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // Login bem-sucedido, redirecione para a página inicial ou outra página
                return RedirectToAction("Index", "Home");
            }
            
            ModelState.AddModelError(string.Empty, "Senha incorreta!");

            return Login();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            ModelState.AddModelError(string.Empty, "Ocorreu um erro ao tentar fazer login.");
            return Login();
        }
    }
}