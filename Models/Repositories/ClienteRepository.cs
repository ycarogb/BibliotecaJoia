using WebApp.Models.Entidades;
using WebApp.Models.Interfaces.Repositories;

namespace WebApp.Models.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly IContextData _contextData;

    public ClienteRepository(IContextData contextData)
    {
        _contextData = contextData;
    }

    public void Cadastrar(Cliente Cliente)
    {
        _contextData.CadastrarCliente(Cliente);
    }

    public List<Cliente> Listar()
    {
        return _contextData.ListarCliente();
    }

    public Cliente ObterPorId(string id)
    {
        return _contextData.ObterClientePorId(id);
    }

    public void Atualizar(Cliente Cliente)
    {
        _contextData.AtualizarCliente(Cliente);
    }

    public void Excluir(string id)
    {
        _contextData.ExcluirCliente(id);
    }
}