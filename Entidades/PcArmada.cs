
namespace CompumundoApis.Entidades;

public class PcArmada
{
    public int PcArmadaId{ get; set; }
    public string Nombre { get; set; }
    public decimal PrecioTotal { get; set; }
    public string Descripcion { get; set; }
    public List<Producto> Componentes { get; set; }
    public int IdProducto { get; set; }
    public int IdDetallePedido { get; set; }
}