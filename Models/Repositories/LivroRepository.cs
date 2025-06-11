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
        _context.CadastrarLivro(livro);
    }

    public List<Livro> Listar()
    {
        return _context.ListarLivro();
    }

    public Livro ObterPorId(string id)
    {
        return _context.ObterLivroPorId(id);
    }

    public void Atualizar(Livro livro)
    {
        _context.AtualizarLivro(livro);
    }

    public void Excluir(string id)
    {
        _context.ExcluirLivro(id);
    }

    public void Emprestar(EmprestimoLivro novoEmprestimo)
    {
        _context.EmprestarLivro(novoEmprestimo);
    }
}