

using CompumundoApis;
using CompumundoApis.Datos;
using CompumundoApis.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CompumundoApis.Repositorios;
public class ProveedorRepositorio : IProveedorRepositorio
{
    private readonly AppDbContext _context;

    public ProveedorRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Proveedor> ObtenerProveedorPorId(int id)
    {
        return await _context.Proveedores.FindAsync(id);
    }

    public async Task<IEnumerable<Proveedor>> ObtenerTodosLosProveedores()
    {
        return await _context.Proveedores.ToListAsync();
    }

    public async Task<Proveedor> CrearProveedor(Proveedor proveedor)
    {
        _context.Proveedores.Add(proveedor);
        await _context.SaveChangesAsync();
        return proveedor;
    }

    public async Task<Proveedor> ActualizarProveedor(int id, Proveedor proveedor)
    {
        var proveedorExistente = await _context.Proveedores.FindAsync(id);
        if (proveedorExistente == null)
        {
            return null;
        }

        proveedorExistente.Nombre = proveedor.Nombre;
        proveedorExistente.Contacto = proveedor.Contacto;
        proveedorExistente.CorreoElectronico = proveedor.CorreoElectronico;

        await _context.SaveChangesAsync();
        return proveedorExistente;
    }

    public async Task<bool> EliminarProveedor(int id)
    {
        var proveedor = await _context.Proveedores.FindAsync(id);
        if (proveedor == null)
        {
            return false;
        }

        _context.Proveedores.Remove(proveedor);
        await _context.SaveChangesAsync();
        return true;
    }
}