using WebApp.Models.Dtos;
using WebApp.Models.Entidades;
using WebApp.Models.Interfaces.Repositories;

namespace WebApp.Models.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IContextData _contextData;

    public UsuarioRepository(IContextData contextData)
    {
        _contextData = contextData;
    }

    public void Cadastrar(Usuario usuario)
    {
        _contextData.CadastrarUsuario(usuario);
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

    public UsuarioDto EfetuarLogin(UsuarioDto usuarioDto)
    {
        return _contextData.EfetuarLogin(usuarioDto);
    }
}