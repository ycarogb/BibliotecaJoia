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

    public List<Livro> ListarEmprestados(string idUsuario)
    {
        return _context.ListarLivrosEmprestados(idUsuario);
    }

    public void InserirDataDevolucaoEmprestimo(EmprestimoLivro emprestimoAtualizado)
    {
        _context.InserirDataDevolucaoEfetivaEmprestimo(emprestimoAtualizado);
    }

    public EmprestimoLivro ObterEmprestimoLivro(string livroId, string idUsuario)
    {
        return _context.ObterEmprestimoLivro(livroId, idUsuario);
    }
}