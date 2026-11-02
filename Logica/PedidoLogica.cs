using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;


namespace CompumundoApis.Logica;

public class PedidoLogica : IPedidoLogica
{
    private readonly IPedidoRepositorio _pedidoRepositorio;

    public PedidoLogica(IPedidoRepositorio pedidoRepositorio)
    {
        _pedidoRepositorio = pedidoRepositorio;
    }

    public async Task<Pedido> ObtenerPedidoPorId(int id)
    {
        return await _pedidoRepositorio.ObtenerPedidoPorId(id);
    }

    public async Task<IEnumerable<Pedido>> ObtenerTodosLosPedidos()
    {
        return await _pedidoRepositorio.ObtenerTodosLosPedidos();
    }

    public async Task<Pedido> CrearPedido(Pedido pedido)
    {
        return await _pedidoRepositorio.CrearPedido(pedido);
    }

    public async Task<Pedido> ActualizarPedido(int id, Pedido pedido)
    {
        return await _pedidoRepositorio.ActualizarPedido(id, pedido);
    }

    public async Task<bool> EliminarPedido(int id)
    {
        return await _pedidoRepositorio.EliminarPedido(id);
    }
}