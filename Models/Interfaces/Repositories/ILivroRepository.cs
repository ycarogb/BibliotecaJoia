using WebApp.Models.Dtos;

namespace WebApp.Models.Interfaces.Repositories;

public interface ILivroRepository
{
    List<LivroDto> Listar();
}