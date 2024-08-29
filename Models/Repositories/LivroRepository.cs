using WebApp.Models.Dtos;
using WebApp.Models.Interfaces.Repositories;

namespace WebApp.Models.Repositories;

public class LivroRepository : ILivroRepository
{
    public void Cadastrar(LivroDto livro)
    {
        //TODO: VALIDAR DADOS DO INPUT
        ContextDataFake.Livros.Add(livro);
    }

    public List<LivroDto> Listar()
    {
        var livros = ContextDataFake.Livros;
        return livros
            .OrderBy(p => p.Nome)
            .ToList();
    }

    public LivroDto ObterPorId(string id)
    {
        var livros = ContextDataFake.Livros;
        return livros.First(p => p.Id == id);
    }

    public void Atualizar(LivroDto livro)
    {
        var livroBanco = ObterPorId(livro.Id);
        ContextDataFake.Livros.Remove(livroBanco);

        livroBanco.Nome = livro.Nome;
        livroBanco.Editora = livro.Editora;
        livroBanco.Autor = livro.Autor;
        
        Cadastrar(livroBanco);
    }
}