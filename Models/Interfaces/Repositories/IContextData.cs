using WebApp.Models.Entidades;

namespace WebApp.Models.Interfaces.Repositories;

public interface IContextData
{
    void Cadastrar(Livro livro);
    List<Livro> Listar();
    Livro ObterPorId(string id);
    void Atualizar(Livro livro);
    void Excluir(string id);
    
}