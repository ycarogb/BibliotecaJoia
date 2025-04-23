using FluentAssertions;
using WebApp.Models.Dtos;
using WebApp.Models.Entidades;
using Xunit;

namespace WebApp.Tests;

public class ClienteUnitTest
{
    [Fact]
    public void Transforma_objeto_dto_em_entidade()
    {
        var clienteDto = new ClienteDto
        {
            Id = Guid.NewGuid().ToString(),
            Nome = "ClienteTeste",
            Cpf = "12345678910",
            Email = "Email@Teste.com",
            IdStatusCliente = 1,
            Telefone = "12345678"
        };

        var result = clienteDto.ConverterParaEntidade();

        result.Id.Should().Be(clienteDto.Id);
        result.Nome.Should().Be(clienteDto.Nome);
        result.Cpf.Should().Be(clienteDto.Cpf);
        result.Email.Should().Be(clienteDto.Email);
        result.Telefone.Should().Be(clienteDto.Telefone);
        result.IdStatusCliente.Should().Be(clienteDto.IdStatusCliente);
        result.Status.Should().Be(clienteDto.Status);
    }
}