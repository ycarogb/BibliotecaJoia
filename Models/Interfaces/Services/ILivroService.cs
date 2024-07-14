using WebApp.Models.Dtos;

namespace WebApp.Models.Interfaces.Services;

public interface ILivroService
{
    List<LivroDto> Listar();
}