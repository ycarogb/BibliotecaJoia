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
    
    [HttpGet]
    public IActionResult Registrar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(string email, string senha)
    {
        if (!ModelState.IsValid)
            return View();

        var novoUsuario = new Usuario
        {
            UserName = email,
            Email = email,
            Login = email,
            Senha = senha,
            UserType = "Administrador"
        };

        var resultado = await _userManager.CreateAsync(novoUsuario, senha);
        if (resultado.Succeeded)
        {
            //await _signInManager.SignInAsync(novoUsuario, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        foreach (var erro in resultado.Errors)
            ModelState.AddModelError("", erro.Description);

        return View();
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string senha)
    {
        if (!ModelState.IsValid)
            return View();

        var resultado = await _signInManager.PasswordSignInAsync(email, senha, isPersistent: false, lockoutOnFailure: false);
        if (resultado.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "E-mail ou senha inválidos.");
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}