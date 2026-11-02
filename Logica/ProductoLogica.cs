using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;


namespace CompumundoApis.Logica;

public class ProductoLogica : IProductoLogica
{
    private readonly IProductoRepositorio _productoRepositorio;

    public ProductoLogica(IProductoRepositorio productoRepositorio)
    {
        _productoRepositorio = productoRepositorio;
    }

    public async Task<Producto> ObtenerProductoPorId(int id)
    {
        return await _productoRepositorio.ObtenerProductoPorId(id);
    }

    public async Task<IEnumerable<Producto>> ObtenerTodosLosProductos()
    {
        return await _productoRepositorio.ObtenerTodosLosProductos();
    }

    public async Task<Producto> CrearProducto(Producto producto)
    {
        return await _productoRepositorio.CrearProducto(producto);
    }

    public async Task<Producto> ActualizarProducto(int id, Producto producto)
    {
        return await _productoRepositorio.ActualizarProducto(id, producto);
    }

    public async Task<bool> EliminarProducto(int id)
    {
        return await _productoRepositorio.EliminarProducto(id);
    }
}