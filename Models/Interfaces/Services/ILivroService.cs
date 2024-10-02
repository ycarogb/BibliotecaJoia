using WebApp.Models.Dtos;

namespace WebApp.Models.Interfaces.Services;

public interface ILivroService
{
    void Cadastrar(LivroDto livro);
    List<LivroDto> Listar();
    LivroDto ObterPorId(string id);
    void EditarLivro(LivroDto livro);
    void Excluir(string id);
}