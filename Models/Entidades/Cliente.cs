using WebApp.Models.Dtos;
using WebApp.Models.Enums;

namespace WebApp.Models.Entidades;

public class Cliente : EntidadeBase
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public int IdStatusCliente { get; set; }
    public StatusCliente Status { get; set; }

    public ClienteDto ConverterParaDto()
    {
        return new ClienteDto()
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

    public void Cadastrar()
    {
        Status = StatusCliente.Ativo;
    }
}