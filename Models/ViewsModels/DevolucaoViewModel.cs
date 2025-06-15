using WebApp.Models.Dtos;

namespace WebApp.Models.ViewsModels;

public class DevolucaoViewModel
{
    public LivroDto Livro { get; set; }
    public bool LivroParaDevolucao { get; set; }
}