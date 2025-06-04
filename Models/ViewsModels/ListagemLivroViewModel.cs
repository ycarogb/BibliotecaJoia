using WebApp.Models.Dtos;

namespace WebApp.Models.ViewsModels;

public class ListagemLivroViewModel
{
    public List<LivroDto> Livros { get; set; }
    public bool Administrador { get; set; }
    public bool Cliente { get; set; }
}