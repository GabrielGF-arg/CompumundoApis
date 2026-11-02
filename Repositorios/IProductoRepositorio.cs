using CompumundoApis.Entidades;

namespace CompumundoApis.Repositorios;
public interface IProductoRepositorio
{
    Task<Producto> ObtenerProductoPorId(int id);
    Task<IEnumerable<Producto>> ObtenerTodosLosProductos();
    Task<Producto> CrearProducto(Producto producto);
    Task<Producto> ActualizarProducto(int id, Producto producto);
    Task<bool> EliminarProducto(int id);
}