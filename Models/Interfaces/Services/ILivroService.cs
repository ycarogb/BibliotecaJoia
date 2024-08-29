using WebApp.Models.Dtos;

namespace WebApp.Models.Interfaces.Services;

public interface ILivroService
{
    void Cadastrar(LivroDto livro);
    List<LivroDto> Listar();
    LivroDto ObterPorId(string Id);
    void EditarLivro(LivroDto livro);
}