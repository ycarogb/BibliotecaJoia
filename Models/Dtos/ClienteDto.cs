using WebApp.Models.Entidades;
using WebApp.Models.Enums;

namespace WebApp.Models.Dtos;

public sealed class ClienteDto : EntidadeBase
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public StatusCliente Status { get; set; } = StatusCliente.Ativo;
    public int IdStatusCliente { get; set; } 
    public Cliente ConverterParaEntidade()
    {
        return new Cliente()
        {
            Id = Id,
            Nome = Nome,
            Email = Email,
            Telefone = Telefone,
            Cpf = Cpf,
            Status = Status,
            IdStatusCliente = (int)Status
        };
    }
}