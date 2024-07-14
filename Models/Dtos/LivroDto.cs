namespace WebApp.Models.Dtos;

public class LivroDto
{
    public string Id { get; set; } 
    public string Nome { get; set; }
    public string Autor { get; set; }
    public string Editora { get; set; }

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