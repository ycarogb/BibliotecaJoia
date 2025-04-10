using WebApp.Models.Entidades;

namespace WebApp.Models.Interfaces.Repositories;

public interface IClienteRepository
{
    void Cadastrar(Cliente Cliente);
    List<Cliente> Listar();
    Cliente ObterPorId(string id);
    void Atualizar(Cliente Cliente);
    void Excluir(string id);
}