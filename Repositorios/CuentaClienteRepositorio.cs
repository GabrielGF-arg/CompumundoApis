using Microsoft.EntityFrameworkCore;
using CompumundoApis.Entidades;
using CompumundoApis.Datos;


namespace CompumundoApis.Repositorios;

public class CuentaClienteRepositorio : ICuentaClienteRepositorio
{
    private readonly AppDbContext _context;

    public CuentaClienteRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CuentaCliente> CrearCuentaCliente(CuentaCliente cuentaCliente)
    {
        _context.CuentaClientes.Add(cuentaCliente);
        await _context.SaveChangesAsync();
        return cuentaCliente;
    }

    public async Task<CuentaCliente> ObtenerCuentaClientePorId(int id)
    {
        return await _context.CuentaClientes.FindAsync(id);
    }

    public async Task<IEnumerable<CuentaCliente>> ObtenerTodasLasCuentasClientes()
    {
        return await _context.CuentaClientes.ToListAsync();
    }

    public async Task<CuentaCliente> ActualizarCuentaCliente(int id, CuentaCliente cuentaCliente)
    {
        _context.CuentaClientes.Update(cuentaCliente);
        await _context.SaveChangesAsync();
        return cuentaCliente;
    }

    public async Task<bool> EliminarCuentaCliente(int id)
    {
        var cuentaCliente = await _context.CuentaClientes.FindAsync(id);
        if (cuentaCliente != null)
        {
            _context.CuentaClientes.Remove(cuentaCliente);
            await _context.SaveChangesAsync();
        }
        return true;
    }
}