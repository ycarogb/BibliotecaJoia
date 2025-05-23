using WebApp.Models.Dtos;
using WebApp.Models.Entidades;

namespace WebApp.Models.Interfaces.Repositories;

public interface IUsuarioRepository : IRepository<Usuario, int>
{
    UsuarioDto? EfetuarLogin(UsuarioDto usuarioDto);
    Task<Usuario?> ObterPorEmailAsync(string email);
    Task CriarAsync(Usuario usuario, string senha);
    Task<bool> VerificarSenhaAsync(Usuario usuario, string senha);
}