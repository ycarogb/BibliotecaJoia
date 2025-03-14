using WebApp.Models.Dtos;
using WebApp.Models.Entidades;
using WebApp.Models.Interfaces.Repositories;

namespace WebApp.Models.Context;

public class ContextDataFake : IContextData
{
    private static List<Livro> _livros = new List<Livro>();

    public ContextDataFake()
    {
        InitializeData();
    }

    private static void InitializeData()
    {
        if (_livros.Any()) return;

        var livro = new Livro
        {
            Nome = "Implementanto Domain-Driven Design", Autor = "Vaigh Vernon", Editora = "Alta Books"
        };
        _livros.Add(livro);

        livro = new Livro
        {
            Nome = "Refatoração", Autor = "Eric Evans", Editora = "Alta Books"
        };
        _livros.Add(livro);

        livro = new Livro
        {
            Nome = "Redes Guia Prático", Autor = "Carlos Marimoto", Editora = "Sul Editores"
        };
        _livros.Add(livro);

        livro = new Livro
        {
            Nome = "PHP Programando com Orientação a Objetos", Autor = "Pablo Dall'Oglio", Editora = "Novatec"
        };
        _livros.Add(livro);

        livro = new Livro
        {
            Nome = "Introdução a Programação com Python", Autor = "Nilo C. Menezes", Editora = "Novatec"
        };
        _livros.Add(livro);
    }

    public void Cadastrar(Livro livro)
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

    public List<Livro> Listar()
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

    public Livro ObterPorId(string id)
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
    public void Atualizar(Livro livro)
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