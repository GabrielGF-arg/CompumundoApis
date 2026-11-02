using CompumundoApis.Entidades;
using CompumundoApis.Logica;
using Microsoft.AspNetCore.Mvc;




namespace CompumundoApis.Endpoints;
public static class ProductoEndpoint
{
   public static void MapProductoEndpoints(this WebApplication app)
    {
        // 1. Obtener todos los productos (GET)
        app.MapGet("/Producto", async (
            [FromServices] IProductoLogica productoLogica) =>
        {
            var productos = await productoLogica.ObtenerTodosLosProductos();
            return Results.Ok(productos);
        });

        // 2. Obtener producto por ID (GET)
        app.MapGet("/Producto/{id}", async (
            [FromServices] IProductoLogica productoLogica, 
            [FromRoute] int id) =>
        {
            var producto = await productoLogica.ObtenerProductoPorId(id);
            
            if (producto == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(producto);
        });

        // 3. Crear producto (POST)
        app.MapPost("/Producto", async (
            [FromServices] IProductoLogica productoLogica, 
            [FromBody] Producto producto) =>
        {
            var nuevoProducto = await productoLogica.CrearProducto(producto);
            
            return Results.Created($"/Producto/{nuevoProducto.id}", nuevoProducto); 
        });

        // 4. Actualizar producto (PUT)
        app.MapPut("/Producto/{id}", async (
            [FromServices] IProductoLogica productoLogica, 
            [FromRoute] int id, 
            [FromBody] Producto producto) =>
        {
            var productoActualizado = await productoLogica.ActualizarProducto(id, producto);
            
            if (productoActualizado == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(productoActualizado);
        });

        // 5. Eliminar producto (DELETE)
        app.MapDelete("/Producto/{id}", async (
            [FromServices] IProductoLogica productoLogica, 
            [FromRoute] int id) =>
        {
            var eliminado = await productoLogica.EliminarProducto(id);
            
            if (!eliminado)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });
    }
}