using WebApp.Models.Dtos;
using WebApp.Models.Entidades;
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
            var objetoLivro = livro.ConverterParaEntidade();
            objetoLivro.Cadastrar();
            _livroRepository.Cadastrar(objetoLivro);
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
            var objetoslivros = _livroRepository.Listar();
            var livros = new List<LivroDto>();
            foreach (var livro in objetoslivros)
            {
                var novoLivro = livro.ConverterParaDto();
                livros.Add(novoLivro);
            }

            return livros;
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
            var objetoLivro =  _livroRepository.ObterPorId(Id);
            var livroDto = objetoLivro.ConverterParaDto();
            return livroDto;
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
            var objetoLivro = livro.ConverterParaEntidade();
            _livroRepository.Atualizar(objetoLivro);
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