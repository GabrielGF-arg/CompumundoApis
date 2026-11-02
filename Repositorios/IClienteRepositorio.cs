using CompumundoApis.Entidades;


namespace CompumundoApis.Repositorios;

public interface IClienteRepositorio
{
    public Task<Cliente> CrearCliente(Cliente cliente);
    public Task<Cliente> ObtenerClientePorId(int id);
    public Task<IEnumerable<Cliente>> ObtenerTodosLosClientes();
    public Task<Cliente> ActualizarCliente(Cliente cliente);
    public Task<bool> EliminarCliente(int id);
}