
namespace CompumundoApis.Entidades;

public class Ventas
{
    public int VentasId {get;set;}
    public string ProductoVendido {get;set;}
    public decimal PrecioVenta {get;set;}
    public DateTime FechaVenta {get;set;}
    public int NombreComprador {get;set;}
    
}