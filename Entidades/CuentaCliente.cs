
namespace CompumundoApis.Entidades;

public class CuentaCliente
{
    public int CuentaClienteId {get; set;}
    public string Facturacion {get; set;}
    public string Pais {get; set;}
    public string provincia {get; set;}
    public string Ciudad {get; set;}
    public string CodigoPostal {get; set;}
    public string Calle {get; set;}
    public string NumeroCalle {get; set;}
    public int? ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
}
