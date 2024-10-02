using WebApp.Models.Dtos;
using WebApp.Models.Interfaces.Repositories;
using WebApp.Models.Interfaces.Services;

namespace WebApp.Models.Services;

public class LivroService : ILivroService
{
    private readonly ILivroRepository _livroRepository;

    public LivroService(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    public void Cadastrar(LivroDto livro)
    {
        try
        {
            _livroRepository.Cadastrar(livro);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public List<LivroDto> Listar()
    {
        try
        {
            return _livroRepository.Listar();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public LivroDto ObterPorId(string Id)
    {
        try
        {
            return _livroRepository.ObterPorId(Id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void EditarLivro(LivroDto livro)
    {
        try
        {
            _livroRepository.Atualizar(livro);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void Excluir(string id)
    {
        try
        {
            _livroRepository.Excluir(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}