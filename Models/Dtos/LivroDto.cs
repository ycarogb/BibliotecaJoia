using WebApp.Models.Entidades;
using WebApp.Models.Enums;

namespace WebApp.Models.Dtos;

public class LivroDto : EntidadeBase
{
    public string Nome { get; set; }
    public string Autor { get; set; }
    public string Editora { get; set; }
    public int IdStatusLivro { get; set; }

    //Construtor criado para evitar conflitos na construção do formulário
    public LivroDto()
    {
        
    }

    public Livro ConverterParaEntidade()
    {
        return new Livro()
        {
            Id = Id,
            Nome = Nome,
            Autor = Autor,
            Editora = Editora,
            Status = (StatusLivro)IdStatusLivro
        };
    }
}