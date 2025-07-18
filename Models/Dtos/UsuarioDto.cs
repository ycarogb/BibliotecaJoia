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
    public bool IsAdmin { get; set; }

    public Usuario ConverterParaEntidade()
    {
        var result = new Usuario()
        {
            Login = Email,
            UserName = Email,
            Senha = Senha,
            Nome = Nome,
            Telefone = Telefone,
            Cpf = Cpf,
            Email = Email,
            UserType = IsAdmin ? "Administrador" : "Cliente"
        };

        return result;
    }
}