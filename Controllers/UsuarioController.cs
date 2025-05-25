using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dtos;
using WebApp.Models.Entidades;
using WebApp.Models.Interfaces.Services;

namespace WebApp.Controllers;

[Authorize(Roles = "Administrador")]
public class UsuarioController: Controller
{
    private readonly IUsuarioService _usuarioService;
    private readonly SignInManager<Usuario> _signInManager;

    public UsuarioController(IUsuarioService usuarioService, SignInManager<Usuario> signInManager)
    {
        _usuarioService = usuarioService;
        _signInManager = signInManager;
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

    public IActionResult Edit(string id)
    {
        if (id == null) return NotFound();
        
        var usuario = _usuarioService.ObterPorId(id);
        if (usuario == null) return NotFound();

        return View(usuario);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([Bind("Id, Login, Senha")] UsuarioDto usuario)
    {
        if (usuario.Id == null)
            return NotFound();
        
        try
        {
            var resultadoVerificacao = VerificarErrosNaSenha(usuario.Senha);
            if (resultadoVerificacao != null) return resultadoVerificacao; 
            
            await _usuarioService.EditarAsync(usuario);
            return Json(new { success = true }); 
        }
        catch (Exception e)
        {
            return Json(new { success = false, message = "Ocorreu um erro ao editar o usuário." });
        }
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
    
    public IActionResult Delete(string id)
    {
        if (id == null)
            return NotFound();

        var usuario = _usuarioService.ObterPorId(id);
        if (usuario == null)
            return NotFound();
        
        return View(usuario);
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete([Bind("Id, Login, Senha")] UsuarioDto usuario)
    {
        try
        {
            if (!ModelState.IsValid) return View();
            await _usuarioService.ExcluirAsync(usuario.Id);
            return RedirectToAction("List");
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Registrar()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Registrar(string email, string senha, bool isAdmin)
    {
        if (!ModelState.IsValid)
            return View();

        var role = isAdmin ? "Administrador" : "Cliente";
        var resultado = await _usuarioService.CadastrarAsync(email, senha, role);
        return resultado; 
    }
    
    private JsonResult? VerificarErrosNaSenha(string senha)
    {
        var temLetraMaiuscula = senha.Any(char.IsUpper);
        if (!temLetraMaiuscula)
            return Json(new { success = false, message = "A senha deve conter pelo menos uma letra maiúscula." });
        
        var temNumero = senha.Any(char.IsDigit);
        if (!temNumero)
            return Json(new { success = false, message = "A senha deve conter pelo menos um número." });
        
        var temCaractereEspecial = senha.Any(ch => !char.IsLetterOrDigit(ch));
        if (!temCaractereEspecial)
            return Json(new { success = false, message = "A senha deve conter pelo menos um caractere especial." });
        
        return null;
    }
    
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
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
    
    [AllowAnonymous]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}