using WebApp.Models.Dtos;

namespace WebApp.Models.Interfaces.Services;

public interface ILivroService : IService<LivroDto, string>
{
    void Emprestar(LivroDto livro, string usuarioId);
    List<LivroDto> ListarLivrosEmprestados(string? identityName);
    void Devolver(LivroDto livro, string idUsuario);
}