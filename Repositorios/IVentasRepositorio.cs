
using CompumundoApis.Entidades;

namespace CompumundoApis.Repositorios;
public interface IVentasRepositorio
{
    Task<Ventas> ObtenerVentaPorId(int id);
    Task<IEnumerable<Ventas>> ObtenerTodasLasVentas();
    Task<Ventas> CrearVenta(Ventas venta);
    Task<Ventas> ActualizarVenta(int id, Ventas venta);
    Task<bool> EliminarVenta(int id);
}