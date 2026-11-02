using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;



namespace CompumundoApis.Logica;

public interface IDetallePedidoLogica
{
    public Task<DetallePedido> ObtenerDetallePedidoPorId(int id);
    public Task<IEnumerable<DetallePedido>> ObtenerTodosLosDetallesPedidos();
    public Task<DetallePedido> CrearDetallePedido(DetallePedido detallePedido);
    public Task<DetallePedido> ActualizarDetallePedido(int id, DetallePedido detallePedido);
    public Task<bool> EliminarDetallePedido(int id);
}