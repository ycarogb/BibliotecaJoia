using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dtos;

namespace WebApp.Models.Interfaces.Services;

public interface IUsuarioService
{
    List<UsuarioDto> Listar();
    UsuarioDto ObterPorId(string id);
    Task EditarAsync(UsuarioDto usuario);
    Task ExcluirAsync(string usuarioId);
    Task<JsonResult> CadastrarAsync(string email, string senha);
}