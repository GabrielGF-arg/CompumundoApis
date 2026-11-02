using CompumundoApis.Datos;
using CompumundoApis.Entidades;


namespace CompumundoApis.Repositorios;
public class ClienteRepositorio : IClienteRepositorio
{
    private readonly AppDbContext _context;

    public ClienteRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente> CrearCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }
    public async Task<Cliente> ObtenerClientePorId(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        return cliente;
    }

    public Task<IEnumerable<Cliente>> ObtenerTodosLosClientes()
    {
        return Task.FromResult(_context.Clientes.AsEnumerable());
    }
    public async Task<Cliente> ActualizarCliente(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }
    public async Task<bool> EliminarCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}