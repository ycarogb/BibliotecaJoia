using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dtos;
using WebApp.Models.Interfaces.Repositories;
using WebApp.Models.Interfaces.Services;

namespace WebApp.Models.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<JsonResult> CadastrarAsync(string email, string senha, bool isAdmin)
    {
        try
        {
            var result = await _usuarioRepository.CadastrarAsync(email, senha, isAdmin);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<UsuarioDto> Listar()
    {
        try
        {
            var usuarios = _usuarioRepository.Listar();
            var usuarioDtos = new List<UsuarioDto>();
            foreach (var usuario in usuarios)
            {
                usuarioDtos.Add(usuario.ConverterParaDto());
            }

            return usuarioDtos;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public UsuarioDto ObterPorId(string id)
    {
        try
        {
            var usuarioDto = _usuarioRepository.ObterPorId(id).ConverterParaDto();
            return usuarioDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task EditarAsync(UsuarioDto usuarioDto)
    {
        try
        {
            var usuario = usuarioDto.ConverterParaEntidade();
            await _usuarioRepository.AtualizarAsync(usuario);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task ExcluirAsync(string id)
    {
        try
        {
            await _usuarioRepository.ExcluirAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}