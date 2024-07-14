using WebApp.Models.Dtos;
using WebApp.Models.Interfaces.Repositories;
using WebApp.Models.Interfaces.Services;

namespace WebApp.Models.Services;

public class LivroService : ILivroService
{
    private readonly ILivroRepository _livroRepository;

    public LivroService(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    public List<LivroDto> Listar()
    {
        try
        {
            return _livroRepository.Listar();
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}