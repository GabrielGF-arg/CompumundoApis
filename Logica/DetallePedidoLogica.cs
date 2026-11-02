using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;

namespace CompumundoApis.Logica;

public class DetallePedidoLogica : IDetallePedidoLogica
{
    private readonly IDetallePedidoRepositorio _detallePedidoRepositorio;

    public DetallePedidoLogica(IDetallePedidoRepositorio detallePedidoRepositorio)
    {
        _detallePedidoRepositorio = detallePedidoRepositorio;
    }

    public async Task<DetallePedido> ObtenerDetallePedidoPorId(int id)
    {
        return await _detallePedidoRepositorio.ObtenerDetallePedidoPorId(id);
    }

    public async Task<IEnumerable<DetallePedido>> ObtenerTodosLosDetallesPedidos()
    {
        return await _detallePedidoRepositorio.ObtenerTodosLosDetallesPedidos();
    }

    public async Task<DetallePedido> CrearDetallePedido(DetallePedido detallePedido)
    {
        return await _detallePedidoRepositorio.CrearDetallePedido(detallePedido);
    }

    public async Task<DetallePedido> ActualizarDetallePedido(int id, DetallePedido detallePedido)
    {
        return await _detallePedidoRepositorio.ActualizarDetallePedido(id, detallePedido);
    }

    public async Task<bool> EliminarDetallePedido(int id)
    {
        return await _detallePedidoRepositorio.EliminarDetallePedido(id);
    }
}