using WebApp.Models.Dtos;

namespace WebApp.Models.Interfaces.Repositories;

public interface ILivroRepository
{
    void Cadastrar(LivroDto livro);
    List<LivroDto> Listar();
    LivroDto ObterPorId(string id);
    void Atualizar(LivroDto livro);
}