using Microsoft.AspNetCore.Identity;
using WebApp.Models.Context;
using WebApp.Models.Dtos;
using WebApp.Models.Entidades;
using WebApp.Models.Interfaces.Repositories;

namespace WebApp.Models.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IContextData _contextData;
    private readonly IdentityContext _context;
    private readonly UserManager<Usuario> _userManager;

    public UsuarioRepository(IContextData contextData, IdentityContext context, UserManager<Usuario> userManager)
    {
        _contextData = contextData;
        _context = context;
        _userManager = userManager;
    }

    public void Cadastrar(Usuario usuario)
    {
        _contextData.CadastrarUsuario(usuario);
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public List<Usuario> Listar()
    {
        return _contextData.ListarUsuarios();
    }

    public Usuario ObterPorId(int id)
    {
        return _contextData.ObterUsuarioPorId(id);
    }

    public void Atualizar(Usuario usuario)
    {
        _contextData.AtualizarUsuario(usuario);
    }

    public void Excluir(int id)
    {
        _contextData.ExcluirUsuario(id);
    }

    public UsuarioDto? EfetuarLogin(UsuarioDto usuarioDto)
    {
        return _contextData.EfetuarLogin(usuarioDto);
    }

    public async Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task CriarAsync(Usuario usuario, string senha)
    {
        var result = await _userManager.CreateAsync(usuario, senha);
        if (!result.Succeeded)
        {
            throw new Exception("Erro ao criar usuário: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }

    public async Task<bool> VerificarSenhaAsync(Usuario usuario, string senha)
    {
        return await _userManager.CheckPasswordAsync(usuario, senha);
    }
}