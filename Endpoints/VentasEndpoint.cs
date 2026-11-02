using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompumundoApis.Logica;
using CompumundoApis.Entidades;
using Microsoft.AspNetCore.Mvc;




namespace CompumundoApis.Endpoints;
public static class VentasEndpoint
{
   public static void MapVentasEndpoints(this WebApplication app)
    {
        // 1. Obtener todas las ventas (GET)
        app.MapGet("/Ventas", async (
            [FromServices] IVentasLogica ventasLogica) =>
        {
            var ventas = await ventasLogica.ObtenerTodasLasVentas();
            return Results.Ok(ventas);
        });

        // 2. Obtener venta por ID (GET)
        app.MapGet("/Ventas/{id}", async (
            [FromServices] IVentasLogica ventasLogica, 
            [FromRoute] int id) =>
        {
            var venta = await ventasLogica.ObtenerVentaPorId(id);
            
            if (venta == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(venta);
        });

        // 3. Crear venta (POST)
        app.MapPost("/Ventas", async (
            [FromServices] IVentasLogica ventasLogica, 
            [FromBody] Ventas venta) =>
        {
            var nuevaVenta = await ventasLogica.CrearVenta(venta);
            
            return Results.Created($"/Ventas/{nuevaVenta.VentasId}", nuevaVenta); 
        });

        // 4. Actualizar venta (PUT)
        app.MapPut("/Ventas/{id}", async (
            [FromServices] IVentasLogica ventasLogica, 
            [FromRoute] int id, 
            [FromBody] Ventas venta) =>
        {
            var ventaActualizada = await ventasLogica.ActualizarVenta(id, venta);
            
            if (ventaActualizada == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(ventaActualizada);
        });

        // 5. Eliminar venta (DELETE)
        app.MapDelete("/Ventas/{id}", async (
            [FromServices] IVentasLogica ventasLogica, 
            [FromRoute] int id) =>
        {
            var eliminado = await ventasLogica.EliminarVenta(id);
            
            if (!eliminado)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });
    }
}