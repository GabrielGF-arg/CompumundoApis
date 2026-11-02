using CompumundoApis.Entidades;

namespace CompumundoApis.Repositorios;
public interface IPedidoRepositorio
{
    Task<Pedido> ObtenerPedidoPorId(int id);
    Task<IEnumerable<Pedido>> ObtenerTodosLosPedidos();
    Task<Pedido> CrearPedido(Pedido pedido);
    Task<Pedido> ActualizarPedido(int id, Pedido pedido);
    Task<bool> EliminarPedido(int id);
}