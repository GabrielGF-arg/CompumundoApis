using CompumundoApis.Entidades;
using CompumundoApis.Datos;
using Microsoft.EntityFrameworkCore;

namespace CompumundoApis.Repositorios;

public class DetallePedidoRepositorio : IDetallePedidoRepositorio
{
    private readonly AppDbContext _context;

    public DetallePedidoRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<DetallePedido> ObtenerDetallePedidoPorId(int id)
    {
        return await _context.DetallesPedidos.FindAsync(id);
    }

    public async Task<IEnumerable<DetallePedido>> ObtenerTodosLosDetallesPedidos()
    {
        return await _context.DetallesPedidos.ToListAsync();
    }

    public async Task<DetallePedido> CrearDetallePedido(DetallePedido detallePedido)
    {
        _context.DetallesPedidos.Add(detallePedido);
        await _context.SaveChangesAsync();
        return detallePedido;
    }

    public async Task<DetallePedido> ActualizarDetallePedido(int id, DetallePedido detallePedido)
    {
        var detalleExistente = await _context.DetallesPedidos.FindAsync(id);
        if (detalleExistente == null)
        {
            return null;
        }

        detalleExistente.IdProducto = detallePedido.IdProducto;


        await _context.SaveChangesAsync();
        return detalleExistente;
    }

    public async Task<bool> EliminarDetallePedido(int id)
    {
        var detalleExistente = await _context.DetallesPedidos.FindAsync(id);
        if (detalleExistente == null)
        {
            return false;
        }

        _context.DetallesPedidos.Remove(detalleExistente);
        await _context.SaveChangesAsync();
        return true;
    }
}