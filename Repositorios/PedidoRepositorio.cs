using CompumundoApis.Datos;
using Microsoft.EntityFrameworkCore;
using CompumundoApis.Entidades;



namespace CompumundoApis.Repositorios;

public class PedidoRepositorio : IPedidoRepositorio
{
    private readonly AppDbContext _context;

    public PedidoRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Pedido> ObtenerPedidoPorId(int id)
    {
        return await _context.Pedidos.FindAsync(id);
    }

    public async Task<IEnumerable<Pedido>> ObtenerTodosLosPedidos()
    {
        return await _context.Pedidos.ToListAsync();
    }

    public async Task<Pedido> CrearPedido(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<Pedido> ActualizarPedido(int id, Pedido pedido)
    {
        var pedidoExistente = await _context.Pedidos.FindAsync(id);
        if (pedidoExistente == null)
        {
            return null;
        }

        // Actualizar las propiedades del pedido existente con los valores del nuevo pedido
        pedidoExistente.FechaPedido = pedido.FechaPedido;
        pedidoExistente.Total = pedido.Total;
        // Actualiza otras propiedades según sea necesario

        await _context.SaveChangesAsync();
        return pedidoExistente;
    }

    public async Task<bool> EliminarPedido(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
        if (pedido == null)
        {
            return false;
        }

        _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();
        return true;
    }
}