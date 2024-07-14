using WebApplication1.Models.Dtos;

namespace WebApplication1.Models.Services;

public interface ILivroService
{
    List<LivroDto> Listar();
}