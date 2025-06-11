using WebApp.Models.Dtos;
using WebApp.Models.Entidades;
using WebApp.Models.Enums;
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

    public void Editar(LivroDto livro)
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

    public void Emprestar(LivroDto livro, string usuarioId)
    {
        try
        {
            CriarNovoEmprestimo(livro, usuarioId);
            AlterarStatusLivro(livro);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private void AlterarStatusLivro(LivroDto livro)
    {
        var objetoLivro = livro.ConverterParaEntidade();
        objetoLivro.Status = StatusLivro.Emprestado;
        _livroRepository.Atualizar(objetoLivro);
    }

    private void CriarNovoEmprestimo(LivroDto livro, string usuarioId)
    {
        var novoEmprestimo = new EmprestimoLivro()
        {
            UsuarioId = usuarioId,
            LivroId = livro.Id
        };
            
        _livroRepository.Emprestar(novoEmprestimo);
    }
}