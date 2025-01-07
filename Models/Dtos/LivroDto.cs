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
    public LivroDto(string id, string nome, string autor, string editora) : this(nome, autor, editora)
    {
        Id = id;
    }

    public LivroDto(string nome, string autor, string editora)
    {
        Nome = nome;
        Autor = autor;
        Editora = editora;
    }
}