
namespace CompumundoApis.Entidades;
public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string CorreoElectronico { get; set; }
    public string Contrasenia { get; set; }
    public List<CuentaCliente> Cuentas { get; set; } = [];
    public List<Pedido> Pedidos { get; set; } = [];
}
