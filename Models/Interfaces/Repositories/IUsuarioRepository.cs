using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Entidades;

namespace WebApp.Models.Interfaces.Repositories;

public interface IUsuarioRepository 
{
    Task<JsonResult> CadastrarAsync(string email, string senha);
    List<Usuario> Listar();
    Usuario ObterPorId(string id);
    Task AtualizarAsync(Usuario usuario);
    Task ExcluirAsync(string id);
}