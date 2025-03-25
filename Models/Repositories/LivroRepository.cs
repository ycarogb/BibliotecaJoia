using WebApp.Models.Entidades;
using WebApp.Models.Interfaces.Repositories;

namespace WebApp.Models.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly IContextData _context;
    public LivroRepository(IContextData context)
    {
        _context = context;
    }
    public void Cadastrar(Livro livro)
    {
        //TODO: VALIDAR DADOS DO INPUT
        _context.Cadastrar(livro);
    }

    public List<Livro> Listar()
    {
        return _context.Listar();
    }

    public Livro ObterPorId(string id)
    {
        return _context.ObterPorId(id);
    }

    public void Atualizar(Livro livro)
    {
        _context.Atualizar(livro);
    }

    public void Excluir(string id)
    {
        _context.Excluir(id);
    }
}