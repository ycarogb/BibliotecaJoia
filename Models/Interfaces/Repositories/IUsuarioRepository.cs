using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dtos;
using WebApp.Models.Entidades;

namespace WebApp.Models.Interfaces.Repositories;

public interface IUsuarioRepository 
{
    Task<JsonResult> CadastrarAsync(UsuarioDto novoUsuario);
    List<Usuario> Listar();
    Usuario ObterPorId(string id);
    Task AtualizarAsync(Usuario usuario);
    Task ExcluirAsync(string id);
    Usuario ObterPorEmail(string emailUsuario);
}