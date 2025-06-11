using WebApp.Models.Entidades;

namespace WebApp.Models.Interfaces.Repositories;

public interface ILivroRepository : IRepository<Livro, string>
{
    void Emprestar(EmprestimoLivro novoEmprestimo);
}