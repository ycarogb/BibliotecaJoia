using Microsoft.AspNetCore.Identity;
using WebApp.Models.Dtos;

namespace WebApp.Models.Entidades;

public class Usuario : IdentityUser
{
    public Usuario()
    {
        Email = Login;
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
            Login = Login,
            Senha = Senha
        };

        return result;
    }
}