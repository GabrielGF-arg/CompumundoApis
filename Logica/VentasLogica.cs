using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;



namespace CompumundoApis.Logica;
public class VentasLogica : IVentasLogica
{
    private readonly IVentasRepositorio _ventasRepositorio;

    public VentasLogica(IVentasRepositorio ventasRepositorio)
    {
        _ventasRepositorio = ventasRepositorio;
    }

    public async Task<Ventas> ObtenerVentaPorId(int id)
    {
        return await _ventasRepositorio.ObtenerVentaPorId(id);
    }

    public async Task<IEnumerable<Ventas>> ObtenerTodasLasVentas()
    {
        return await _ventasRepositorio.ObtenerTodasLasVentas();
    }

    public async Task<Ventas> CrearVenta(Ventas venta)
    {
        return await _ventasRepositorio.CrearVenta(venta);
    }

    public async Task<Ventas> ActualizarVenta(int id, Ventas venta)
    {
        return await _ventasRepositorio.ActualizarVenta(id, venta);
    }

    public async Task<bool> EliminarVenta(int id)
    {
        return await _ventasRepositorio.EliminarVenta(id);
    }

    

}