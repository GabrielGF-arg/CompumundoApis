using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;



namespace CompumundoApis.Logica;

public interface IPedidoLogica
{
    public Task<Pedido> ObtenerPedidoPorId(int id);
    public Task<IEnumerable<Pedido>> ObtenerTodosLosPedidos();
    public Task<Pedido> CrearPedido(Pedido pedido);
    public Task<Pedido> ActualizarPedido(int id, Pedido pedido);
    public Task<bool> EliminarPedido(int id);
}