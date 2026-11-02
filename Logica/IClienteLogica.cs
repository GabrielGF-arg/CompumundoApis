using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;


namespace CompumundoApis.Logica;

public interface IClienteLogica
{
    public Task<Cliente> CrearCliente(Cliente cliente);
    public Task<Cliente> ObtenerClientePorId(int id);
    public Task<IEnumerable<Cliente>> ObtenerTodosLosClientes();
    public Task<Cliente> ActualizarCliente(int id, Cliente cliente);
    public Task<bool> EliminarCliente(int id);
    
}