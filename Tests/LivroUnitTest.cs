using FluentAssertions;
using WebApp.Models.Entidades;
using WebApp.Models.Enums;
using Xunit;

namespace WebApp.Tests;

public class LivroUnitTest
{
    [Fact]
    public void Transforma_entidade_em_dto()
    {
        var livro = new Livro()
        {
            Id = Guid.NewGuid().ToString(),
            Autor = "AutorTeste",
            Editora = "EditoraTeste",
            Nome = "LivroTeste",
            Status = StatusLivro.Disponível
        };

        var resultado = livro.ConverterParaDto();
        resultado.Id.Should().Be(livro.Id);
        resultado.Autor.Should().Be(livro.Autor);
        resultado.Editora.Should().Be(livro.Editora);
        resultado.Nome.Should().Be(livro.Nome);
        resultado.IdStatusLivro.Should().Be((int)livro.Status);
    }
}