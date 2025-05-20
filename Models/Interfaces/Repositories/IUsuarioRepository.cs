using WebApp.Models.Dtos;
using WebApp.Models.Entidades;

namespace WebApp.Models.Interfaces.Repositories;

public interface IUsuarioRepository : IRepository<Usuario, int>
{
    UsuarioDto EfetuarLogin(UsuarioDto usuarioDto);
}