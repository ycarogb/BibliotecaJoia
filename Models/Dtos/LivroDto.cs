namespace WebApplication1.Models.Dtos;

public class ProdutoDto
{
    public string Id { get; set; }
    public string Descricao { get; set; }
    public string Valor { get; set; }

    public ProdutoDto(string id, string descricao, string valor)
    {
        Id = id;
        Descricao = descricao;
        Valor = valor;
    }
}