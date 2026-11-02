using CompumundoApis.Entidades;
using CompumundoApis.Logica;
using Microsoft.AspNetCore.Mvc;



namespace CompumundoApis.Endpoints;
public static class DetallePedidoEndpoint
{
   public static void MapDetallePedidoEndpoints(this WebApplication app)
    {
        // 1. Obtener todos los detalles de pedidos (GET)
        app.MapGet("/DetallePedido", async (
            [FromServices] IDetallePedidoLogica detallePedidoLogica) =>
        {
            var detalles = await detallePedidoLogica.ObtenerTodosLosDetallesPedidos();
            return Results.Ok(detalles);
        });

        // 2. Obtener detalle de pedido por ID (GET)
        app.MapGet("/DetallePedido/{id}", async (
            [FromServices] IDetallePedidoLogica detallePedidoLogica, 
            [FromRoute] int id) =>
        {
            var detalle = await detallePedidoLogica.ObtenerDetallePedidoPorId(id);
            
            if (detalle == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(detalle);
        });

        // 3. Crear detalle de pedido (POST)
        app.MapPost("/DetallePedido", async (
            [FromServices] IDetallePedidoLogica detallePedidoLogica, 
            [FromBody] DetallePedido detallePedido) =>
        {
            var nuevoDetalle = await detallePedidoLogica.CrearDetallePedido(detallePedido);
            
            return Results.Created($"/DetallePedido/{nuevoDetalle.DetallePedidoId}", nuevoDetalle); 
        });

        // 4. Actualizar detalle de pedido (PUT)
        app.MapPut("/DetallePedido/{id}", async (
            [FromServices] IDetallePedidoLogica detallePedidoLogica, 
            [FromRoute] int id, 
            [FromBody] DetallePedido detallePedido) =>
        {
            var detalleActualizado = await detallePedidoLogica.ActualizarDetallePedido(id, detallePedido);
            
            if (detalleActualizado == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(detalleActualizado);
        });

        // 5. Eliminar detalle de pedido (DELETE)
        app.MapDelete("/DetallePedido/{id}", async (
            [FromServices] IDetallePedidoLogica detallePedidoLogica, 
            [FromRoute] int id) =>
        {
            var eliminado = await detallePedidoLogica.EliminarDetallePedido(id);
            
            if (!eliminado)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });
    }
}