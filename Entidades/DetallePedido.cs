
namespace CompumundoApis.Entidades;

public class DetallePedido
{
    public int DetallePedidoId { get; set; }
    public int IdProducto { get; set; }
    public int? PedidoId { get; set; }
    public int Cantidad { get; set; }
    public Decimal PrecioTotal { get; set; }
    public List<Producto> Productos { get; set; }
    public Pedido? Pedido { get; set; }
}
