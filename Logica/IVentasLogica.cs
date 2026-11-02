using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;


namespace CompumundoApis.Logica;

public interface IVentasLogica
{
    public Task<Ventas> ObtenerVentaPorId(int id);
    public Task<IEnumerable<Ventas>> ObtenerTodasLasVentas();
    public Task<Ventas> CrearVenta(Ventas venta);
    public Task<Ventas> ActualizarVenta(int id, Ventas venta);
    public Task<bool> EliminarVenta(int id);
}