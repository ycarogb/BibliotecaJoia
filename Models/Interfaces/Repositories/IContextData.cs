using WebApp.Models.Dtos;

namespace WebApp.Models.Interfaces.Repositories;

public interface IContextData
{
    void Cadastrar(LivroDto livro);
    List<LivroDto> Listar();
    LivroDto ObterPorId(string id);
    void Atualizar(LivroDto livro);
    void Excluir(string id);
    
}