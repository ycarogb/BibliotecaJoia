using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dtos;
using WebApp.Models.Interfaces.Services;

namespace WebApp.Controllers;

[Authorize(Roles = "Administrador")]
public class ClienteController : Controller
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult List()
    {
        try
        {
            var clientes = _clienteService.Listar();
            return View(clientes);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    //Apresenta o cliente que vai ser editado
    public IActionResult Edit(string? id)
    {
        if (id == null)
            return NotFound();
        var cliente = _clienteService.ObterPorId(id);
        if (cliente == null)
            return NotFound();

        return View(cliente);
    }
    
    //Ao clicar em Editar, faz a rotina para atualizar dados de cliente
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit([Bind("Id, Nome, Cpf, Email, Telefone, Status")] ClienteDto cliente)
    {
        if (cliente.Id == null)
            return NotFound();
        try
        {
            _clienteService.Editar(cliente);
            return RedirectToAction("List");
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public IActionResult Details(string? id)
    {
        if (id == null)
            return NotFound();
        var cliente = _clienteService.ObterPorId(id);
        if (cliente == null)
            return NotFound();

        return View(cliente);
    }

    public IActionResult Create()
    {
        try
        {
            return View();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }   
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Nome, Cpf, Email, Telefone")]ClienteDto cliente)
    {
        try
        {
            _clienteService.Cadastrar(cliente);
            return RedirectToAction("List");
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    
    public IActionResult Delete(string? id)
    {
        if (id == null)
            return NotFound();

        var cliente = _clienteService.ObterPorId(id);
        if (cliente == null)
            return NotFound();
        
        return View(cliente);
    }

    [HttpPost]
    public IActionResult Delete([Bind("Id, Nome, Cpf, Email, Telefone, Status")] ClienteDto cliente)
    {
        try
        {
            _clienteService.Excluir(cliente.Id);
            return RedirectToAction("List");
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}