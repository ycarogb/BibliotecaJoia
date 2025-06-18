using Microsoft.AspNetCore.Identity;
using WebApp.Models.Dtos;

namespace WebApp.Models.Entidades;

public class Usuario : IdentityUser
{
    public Usuario()
    {
        UserName = Email;
        Login = Email;
    }

    public string Login { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
    public string Senha { get; set; }
    public string UserType { get; set; }

    public UsuarioDto ConverterParaDto()
    {
        var result = new UsuarioDto()
        {
            Id = Id,
            Login = Email,
            Senha = Senha,
            Nome = Nome,
            Telefone = Telefone,
            Cpf = Cpf,
            Email = Email,
            IsAdmin = UserType == "Administrador"
        };

        return result;
    }
}