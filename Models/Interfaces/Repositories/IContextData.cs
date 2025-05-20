using WebApp.Models.Dtos;
using WebApp.Models.Entidades;

namespace WebApp.Models.Interfaces.Repositories;

public interface IContextData
{
    void CadastrarLivro(Livro livro);
    List<Livro> ListarLivro();
    Livro ObterLivroPorId(string id);
    void AtualizarLivro(Livro livro);
    void ExcluirLivro(string id);
    
    void CadastrarCliente(Cliente Cliente);
    List<Cliente> ListarCliente();
    Cliente ObterClientePorId(string id);
    void AtualizarCliente(Cliente Cliente);
    void ExcluirCliente(string id);

    void CadastrarUsuario(Usuario usuario);
    List<Usuario> ListarUsuarios();
    Usuario ObterUsuarioPorId(int id);
    void AtualizarUsuario(Usuario usuario);
    void ExcluirUsuario(int id);
    UsuarioDto EfetuarLogin(UsuarioDto usuarioDto);
}