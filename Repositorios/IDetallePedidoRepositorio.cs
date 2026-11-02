using CompumundoApis.Entidades;


namespace CompumundoApis.Repositorios;

public interface IDetallePedidoRepositorio
{
    Task<DetallePedido> ObtenerDetallePedidoPorId(int id);
    Task<IEnumerable<DetallePedido>> ObtenerTodosLosDetallesPedidos();
    Task<DetallePedido> CrearDetallePedido(DetallePedido detallePedido);
    Task<DetallePedido> ActualizarDetallePedido(int id, DetallePedido detallePedido);
    Task<bool> EliminarDetallePedido(int id);
}