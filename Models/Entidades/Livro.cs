using WebApp.Models.Enums;

namespace WebApp.Models.Entidades;

public class Livro : EntidadeBase
{
    public string Nome { get; set; }
    public string Autor { get; set; }
    public string Editora { get; set; }
    public StatusLivro Status { get; set; }
}