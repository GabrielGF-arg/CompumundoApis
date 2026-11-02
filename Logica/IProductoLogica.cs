using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;


namespace CompumundoApis.Logica;

public interface IProductoLogica
{
    public Task<Producto> ObtenerProductoPorId(int id);
    public Task<IEnumerable<Producto>> ObtenerTodosLosProductos();
    public Task<Producto> CrearProducto(Producto producto);
    public Task<Producto> ActualizarProducto(int id, Producto producto);
    public Task<bool> EliminarProducto(int id);
}