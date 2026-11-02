using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;
using Microsoft.EntityFrameworkCore;


namespace CompumundoApis.Logica;
public class ClienteLogica : IClienteLogica
{
    private readonly IClienteRepositorio _clienteRepositorio;

    public ClienteLogica(IClienteRepositorio clienteRepositorio)
    {
        _clienteRepositorio = clienteRepositorio;
    }

    public Task<Cliente> CrearCliente(Cliente cliente)
    {
        return _clienteRepositorio.CrearCliente(cliente);
    }

    public Task<Cliente> ObtenerClientePorId(int id)
    {
        return _clienteRepositorio.ObtenerClientePorId(id);
    }

    public Task<IEnumerable<Cliente>> ObtenerTodosLosClientes()
    {
        return _clienteRepositorio.ObtenerTodosLosClientes();
    }

    public Task<Cliente> ActualizarCliente(int id, Cliente cliente)
    {
        _ = id;
        return _clienteRepositorio.ActualizarCliente(cliente);
    }

    public Task<bool> EliminarCliente(int id)
    {
        return _clienteRepositorio.EliminarCliente(id);
    }

}