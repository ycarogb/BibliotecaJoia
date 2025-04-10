using WebApp.Models.Dtos;

namespace WebApp.Models.Interfaces.Services;

public interface IClienteService
{
    void Cadastrar(ClienteDto cliente);
    List<ClienteDto> Listar();
    ClienteDto ObterPorId(string id);
    void EditarCliente(ClienteDto cliente);
    void Excluir(string id);
}