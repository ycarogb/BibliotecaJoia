using WebApp.Models.Entidades;

namespace WebApp.Models.Interfaces.Repositories;

public interface ILivroRepository : IRepository<Livro, string>
{
    void Emprestar(EmprestimoLivro novoEmprestimo);
    List<Livro> ListarEmprestados(string idUsuario);
    void InserirDataDevolucaoEmprestimo(EmprestimoLivro emprestimoAtualizado);
    EmprestimoLivro ObterEmprestimoLivro(string livroId, string idUsuario);
}