using WebApp.Models.Dtos;
using WebApp.Models.Interfaces.Repositories;
using WebApp.Models.Interfaces.Services;

namespace WebApp.Models.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public void Cadastrar(ClienteDto clienteDto)
    {
        var cliente = clienteDto.ConverterParaEntidade();
        _clienteRepository.Cadastrar(cliente);
    }

    public List<ClienteDto> Listar()
    {
        var clientes = _clienteRepository.Listar();
        var clienteDtos = new List<ClienteDto>();
        foreach (var cliente in clientes)
        {
            clienteDtos.Add(cliente.ConverterParaDto());
        }

        return clienteDtos;
    }

    public ClienteDto ObterPorId(string id)
    {
        var clienteDto = _clienteRepository.ObterPorId(id).ConverterParaDto();
        return clienteDto;

    }

    public void EditarCliente(ClienteDto clienteDto)
    {
        var cliente = clienteDto.ConverterParaEntidade();
        _clienteRepository.Atualizar(cliente);
    }

    public void Excluir(string id)
    {
       _clienteRepository.Excluir(id);
    }
}