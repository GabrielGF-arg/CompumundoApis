using CompumundoApis.Datos;
using Microsoft.EntityFrameworkCore;
using CompumundoApis.Entidades;

namespace CompumundoApis.Repositorios;
public class ProductoRepositorio : IProductoRepositorio
{
    private readonly AppDbContext _context;

    public ProductoRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Producto> ObtenerProductoPorId(int id)
    {
        return await _context.Productos.FindAsync(id);
    }

    public async Task<IEnumerable<Producto>> ObtenerTodosLosProductos()
    {
        return await _context.Productos.ToListAsync();
    }

    public async Task<Producto> CrearProducto(Producto producto)
    {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task<Producto> ActualizarProducto(int id, Producto producto)
    {
        var productoExistente = await _context.Productos.FindAsync(id);
        if (productoExistente == null)
        {
            return null;
        }

        productoExistente.Nombre = producto.Nombre;
        productoExistente.Descripcion = producto.Descripcion;
        productoExistente.Precio = producto.Precio;
        productoExistente.Stock = producto.Stock;
        productoExistente.Marca = producto.Marca;
        productoExistente.Modelo = producto.Modelo;
        productoExistente.ImagenUrl = producto.ImagenUrl;
        productoExistente.idDetallePedido = producto.idDetallePedido;
        productoExistente.idProveedor = producto.idProveedor;
        productoExistente.IdAdministrador = producto.IdAdministrador;

        await _context.SaveChangesAsync();
        return productoExistente;
    }

    public async Task<bool> EliminarProducto(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null)
        {
            return false;
        }

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        return true;
    }
}
