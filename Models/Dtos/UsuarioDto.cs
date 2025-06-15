using WebApp.Models.Entidades;

namespace WebApp.Models.Dtos;

public class UsuarioDto
{
    public string Id { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }

    public Usuario ConverterParaEntidade()
    {
        var result = new Usuario()
        {
            Id = Id,
            Login = Login,
            Senha = Senha,
            Nome = Nome,
            Telefone = Telefone,
            Cpf = Cpf,
            Email = Email
        };

        return result;
    }
}