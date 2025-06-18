using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dtos;
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

    public async Task<JsonResult> CadastrarAsync(UsuarioDto novoUsuario)
    {
        var erroSenha = VerificarErrosNaSenha(novoUsuario.Senha);
        if (erroSenha != null) return erroSenha;
        var novoUsuarioEntidade = novoUsuario.ConverterParaEntidade();
        
        var resultado = await _userManager.CreateAsync(novoUsuarioEntidade, novoUsuarioEntidade.Senha);
        if (resultado.Succeeded)
        {
            await _userManager.AddToRoleAsync(novoUsuarioEntidade, novoUsuarioEntidade.UserType);
            await _signInManager.SignInAsync(novoUsuarioEntidade, isPersistent: false);
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
            await _userManager.UpdateAsync(usuario);
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

    public Usuario ObterPorEmail(string emailUsuario)
    {
        var result = _userManager.Users.First(p => p.Email == emailUsuario);
        return result;
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