using CompumundoApis.Entidades;
using CompumundoApis.Logica;
using Microsoft.AspNetCore.Mvc;




namespace CompumundoApis.Endpoints;
public static class ProveedorEndpoint
{
   public static void MapProveedorEndpoints(this WebApplication app)
    {
        // 1. Obtener todos los proveedores (GET)
        app.MapGet("/Proveedor", async (
            [FromServices] IProveedorLogica proveedorLogica) =>
        {
            var proveedores = await proveedorLogica.ObtenerTodosLosProveedores();
            return Results.Ok(proveedores);
        });

        // 2. Obtener proveedor por ID (GET)
        app.MapGet("/Proveedor/{id}", async (
            [FromServices] IProveedorLogica proveedorLogica, 
            [FromRoute] int id) =>
        {
            var proveedor = await proveedorLogica.ObtenerProveedorPorId(id);
            
            if (proveedor == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(proveedor);
        });

        // 3. Crear proveedor (POST)
        app.MapPost("/Proveedor", async (
            [FromServices] IProveedorLogica proveedorLogica, 
            [FromBody] Proveedor proveedor) =>
        {
            var nuevoProveedor = await proveedorLogica.CrearProveedor(proveedor);
            
            return Results.Created($"/Proveedor/{nuevoProveedor.Id}", nuevoProveedor); 
        });

        // 4. Actualizar proveedor (PUT)
        app.MapPut("/Proveedor/{id}", async (
            [FromServices] IProveedorLogica proveedorLogica, 
            [FromRoute] int id, 
            [FromBody] Proveedor proveedor) =>
        {
            var proveedorActualizado = await proveedorLogica.ActualizarProveedor(id, proveedor);
            
            if (proveedorActualizado == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(proveedorActualizado);
        });

        // 5. Eliminar proveedor (DELETE)
        app.MapDelete("/Proveedor/{id}", async (
            [FromServices] IProveedorLogica proveedorLogica, 
            [FromRoute] int id) =>
        {
            var eliminado = await proveedorLogica.EliminarProveedor(id);
            
            if (!eliminado)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });
    }
}