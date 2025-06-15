using WebApp.Models.Dtos;
using WebApp.Models.Enums;

namespace WebApp.Models.Entidades;

public class Livro : EntidadeBase
{
    public string Nome { get; set; }
    public string Autor { get; set; }
    public string Editora { get; set; }
    public int IdStatusLivro { get; set; }
    public StatusLivro Status { get; set; }

    public Livro() : base()
    {
        
    }

    public void Cadastrar()
    {
        Status = StatusLivro.Disponivel;
    }

    public LivroDto ConverterParaDto()
    {
        return new LivroDto()
        {
            Id = Id,
            Autor = Autor,
            Editora = Editora,
            Nome = Nome,
            IdStatusLivro = IdStatusLivro,
        };
    }
}