using CompumundoApis.Datos;
using Microsoft.EntityFrameworkCore;
using CompumundoApis.Logica;
using CompumundoApis.Entidades;

namespace CompumundoApis.Repositorios;

public class VentasRepositorio : IVentasRepositorio
{
    private readonly AppDbContext _context;

    public VentasRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Ventas> ObtenerVentaPorId(int id)
    {
        return await _context.Ventas.FindAsync(id);
    }

    public async Task<IEnumerable<Ventas>> ObtenerTodasLasVentas()
    {
        return await _context.Ventas.ToListAsync();
    }

    public async Task<Ventas> CrearVenta(Ventas venta)
    {
        _context.Ventas.Add(venta);
        await _context.SaveChangesAsync();
        return venta;
    }

    public async Task<Ventas> ActualizarVenta(int id, Ventas venta)
    {
        var ventaExistente = await _context.Ventas.FindAsync(id);
        if (ventaExistente == null)
        {
            return null;
        }

        // Actualizar las propiedades de la venta existente
        ventaExistente.FechaVenta = venta.FechaVenta;
        ventaExistente.PrecioVenta = venta.PrecioVenta;
        // Actualizar otras propiedades según sea necesario

        await _context.SaveChangesAsync();
        return ventaExistente;
    }

    public async Task<bool> EliminarVenta(int id)
    {
        var venta = await _context.Ventas.FindAsync(id);
        if (venta == null)
        {
            return false;
        }

        _context.Ventas.Remove(venta);
        await _context.SaveChangesAsync();
        return true;
    }
}