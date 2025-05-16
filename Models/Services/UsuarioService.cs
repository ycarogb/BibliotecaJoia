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

    public void Cadastrar(UsuarioDto usuarioDto)
    {
        var usuario = usuarioDto.ConverterParaEntidade();
        _usuarioRepository.Cadastrar(usuario);
    }

    public List<UsuarioDto> Listar()
    {
        var usuarios = _usuarioRepository.Listar();
        var usuarioDtos = new List<UsuarioDto>();
        foreach (var usuario in usuarios)
        {
            usuarioDtos.Add(usuario.ConverterParaDto());
        }

        return usuarioDtos;
    }

    public UsuarioDto ObterPorId(int id)
    {
        var usuarioDto = _usuarioRepository.ObterPorId(id).ConverterParaDto();
        return usuarioDto;

    }

    public void Editar(UsuarioDto usuarioDto)
    {
        var usuario = usuarioDto.ConverterParaEntidade();
        _usuarioRepository.Atualizar(usuario);
    }

    public void Excluir(int id)
    {
        _usuarioRepository.Excluir(id);
    }
}