using WebApp.Models.Entidades;

namespace WebApp.Models.Interfaces.Repositories;

public interface IContextData
{
    void CadastrarLivro(Livro livro);
    List<Livro> ListarLivro();
    Livro ObterLivroPorId(string id);
    void AtualizarLivro(Livro livro);
    void ExcluirLivro(string id);
    void EmprestarLivro(EmprestimoLivro novoEmprestimo);
    List<Livro> ListarLivrosEmprestados(string idUsuario);
    EmprestimoLivro ObterEmprestimoLivro(string idLivro, string idUsuario);
    void InserirDataDevolucaoEfetivaEmprestimo(EmprestimoLivro emprestimoAtualizado);
    
    void CadastrarCliente(Cliente Cliente);
    List<Cliente> ListarCliente();
    Cliente ObterClientePorId(string id);
    void AtualizarCliente(Cliente Cliente);
    void ExcluirCliente(string id);
}