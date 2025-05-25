using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Entidades;
using WebApp.Models.Interfaces.Repositories;

namespace WebApp.Models.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;

    public UsuarioRepository(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<JsonResult> CadastrarAsync(string email, string senha, string role)
    {
        var erroSenha = VerificarErrosNaSenha(senha);
        if (erroSenha != null) return erroSenha;
        var novoUsuario = new Usuario
        {
            UserName = email,
            Email = email,
            Login = email,
            Senha = senha
        };
        
        var resultado = await _userManager.CreateAsync(novoUsuario, senha);
        if (resultado.Succeeded)
        {
            await _userManager.AddToRoleAsync(novoUsuario, role);
            await _signInManager.SignInAsync(novoUsuario, isPersistent: false);
            return new JsonResult(new { success = true });
        }
        foreach (var erro in resultado.Errors)
        {
            return new JsonResult(new { success = false, message = erro.Description });
        }
        
        return new JsonResult(new { success = false, message = "Erro ao criar usuário." });
    }
    
    public List<Usuario> Listar()
    {
        return _userManager.Users.ToList();
    }

    public Usuario ObterPorId(string id)
    {
        var result = _userManager.Users.First(p => p.Id == id);
        return result;
    }
    
    public async Task AtualizarAsync(Usuario usuario)
    {
        try
        {
            var usuarioEditado = await _userManager.FindByEmailAsync(usuario.Email);
            usuarioEditado.Senha = usuario.Senha;
            await _userManager.UpdateAsync(usuarioEditado);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task ExcluirAsync(string id)
    {
        var usuario = ObterPorId(id);
        await _userManager.DeleteAsync(usuario);
    }
    
    private JsonResult? VerificarErrosNaSenha(string senha)
    {
        var temLetraMaiuscula = senha.Any(char.IsUpper);
        if (!temLetraMaiuscula)
        {
            var json = new JsonResult(new { success = false, message = "A senha deve conter pelo menos uma letra maiúscula." });
            return json;
        }
        
        var temNumero = senha.Any(char.IsDigit);
        if (!temNumero)
        {
            var json = new JsonResult(new { success = false, message = "A senha deve conter pelo menos um número." });
            return json;
        }
        
        var temCaractereEspecial = senha.Any(ch => !char.IsLetterOrDigit(ch));
        if (!temCaractereEspecial)
        {
            var json = new JsonResult(new { success = false, message = "A senha deve conter pelo menos um caractere especial." });
            return json;
        }
        return null;
    }
}