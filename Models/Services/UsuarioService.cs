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
        try
        {
            var usuario = usuarioDto.ConverterParaEntidade();
            _usuarioRepository.Cadastrar(usuario);
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

    public UsuarioDto ObterPorId(int id)
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

    public void Editar(UsuarioDto usuarioDto)
    {
        try
        {
            var usuario = usuarioDto.ConverterParaEntidade();
            _usuarioRepository.Atualizar(usuario);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Excluir(int id)
    {
        try
        {
            _usuarioRepository.Excluir(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public UsuarioDto? EfetuarLogin(UsuarioDto usuario)
    {
        try
        {
            var usuarioLogado = _usuarioRepository.EfetuarLogin(usuario);
            return usuarioLogado;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;          
        }
    }
}