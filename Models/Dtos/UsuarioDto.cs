using WebApp.Models.Entidades;

namespace WebApp.Models.Dtos;

public class UsuarioDto
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }

    public Usuario ConverterParaEntidade()
    {
        var result = new Usuario()
        {
            Id = Id,
            Login = Login,
            Senha = Senha
        };

        return result;
    }
}