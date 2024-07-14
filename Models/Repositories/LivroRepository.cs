using WebApp.Models.Dtos;
using WebApp.Models.Interfaces.Repositories;

namespace WebApp.Models.Repositories;

public class LivroRepository : ILivroRepository
{
    public List<LivroDto> Listar()
    {
        var livros = ContextDataFake.Livros;
        return livros
            .OrderBy(p => p.Nome)
            .ToList();
    }
}