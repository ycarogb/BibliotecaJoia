using Microsoft.AspNetCore.Identity;
using WebApp.Models.Dtos;

namespace WebApp.Models.Entidades;

public class Usuario : IdentityUser
{
    public string Login { get; set; }
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