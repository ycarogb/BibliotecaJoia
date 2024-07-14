using WebApp.Models.Dtos;

namespace WebApp.Models.Repositories;

public static class ContextDataFake
{
    public static readonly List<LivroDto> Livros;

    static ContextDataFake()
    {
        Livros = new List<LivroDto>();
        InitializeData();
    }

    private static void InitializeData()
    {
        var livro = new LivroDto("Implementanto Domain-Driven Design", "Vaigh Vernon", "Alta Books");
        Livros.Add(livro);
        
        livro = new LivroDto("Refatoração", "Eric Evans", "Alta Books");
        Livros.Add(livro);
        
        livro = new LivroDto("Redes Guia Prático", "Carlos Marimoto", "Sul Editores");
        Livros.Add(livro);
        
        livro = new LivroDto("PHP Programando com Orientação a Objetos", "Pablo Dall'Oglio", "Novatec");
        Livros.Add(livro);
        
        livro = new LivroDto("Introdução a Programação com Python", "Nilo C. Menezes", "Novatec");
        Livros.Add(livro);
    }
}