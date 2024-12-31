using WebApp.Models.Enums;

namespace WebApp.Models.Entidades;

public class Cliente : EntidadeBase
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public StatusCliente Status { get; set; }
}