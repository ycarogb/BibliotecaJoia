using WebApp.Models.Dtos;
using WebApp.Models.Interfaces.Repositories;

namespace WebApp.Models.Context;

public class ContextDataFake : IContextData
{
    private static List<LivroDto> _livros = new List<LivroDto>();

    public ContextDataFake()
    {
        InitializeData();
    }

    private static void InitializeData()
    {
        if (_livros.Any()) return;
        
        var livro = new LivroDto("Implementanto Domain-Driven Design", "Vaigh Vernon", "Alta Books");
        _livros.Add(livro);
        
        livro = new LivroDto("Refatoração", "Eric Evans", "Alta Books");
        _livros.Add(livro);
        
        livro = new LivroDto("Redes Guia Prático", "Carlos Marimoto", "Sul Editores");
        _livros.Add(livro);
        
        livro = new LivroDto("PHP Programando com Orientação a Objetos", "Pablo Dall'Oglio", "Novatec");
        _livros.Add(livro);
        
        livro = new LivroDto("Introdução a Programação com Python", "Nilo C. Menezes", "Novatec");
        _livros.Add(livro);
    }

    public void Cadastrar(LivroDto livro)
    {
        try
        {
            _livros.Add(livro);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<LivroDto> Listar()
    {
        try
        {
            return _livros.OrderBy(p => p.Nome).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;  
        }
    }

    public LivroDto ObterPorId(string id)
    {
        try
        {
            return _livros.First(p => p.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;      
        }
    }

    //TODO: Resolver Atualização que fica repetindo os itens ao final
    public void Atualizar(LivroDto livro)
    {
        try
        {
            var livroEditado = ObterPorId(livro.Id);
            _livros.Remove(livroEditado);

            livroEditado.Nome = livro.Nome;
            livroEditado.Autor = livro.Autor;
            livroEditado.Editora = livro.Editora;
            
            Cadastrar(livroEditado);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Excluir(string id)
    {
        try
        {
            var livro = ObterPorId(id);
            _livros.Remove(livro);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}