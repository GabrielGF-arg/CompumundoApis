using CompumundoApis.Entidades;
using CompumundoApis.Logica;
using Microsoft.AspNetCore.Mvc;




namespace CompumundoApis.Endpoints;
public static class PedidoEndpoint
{
   public static void MapPedidoEndpoints(this WebApplication app)
    {
        // 1. Obtener todos los pedidos (GET)
        app.MapGet("/Pedido", async (
            [FromServices] IPedidoLogica pedidoLogica) =>
        {
            var pedidos = await pedidoLogica.ObtenerTodosLosPedidos();
            return Results.Ok(pedidos);
        });

        // 2. Obtener pedido por ID (GET)
        app.MapGet("/Pedido/{id}", async (
            [FromServices] IPedidoLogica pedidoLogica, 
            [FromRoute] int id) =>
        {
            var pedido = await pedidoLogica.ObtenerPedidoPorId(id);
            
            if (pedido == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(pedido);
        });

        // 3. Crear pedido (POST)
        app.MapPost("/Pedido", async (
            [FromServices] IPedidoLogica pedidoLogica, 
            [FromBody] Pedido pedido) =>
        {
            var nuevoPedido = await pedidoLogica.CrearPedido(pedido);
            
            return Results.Created($"/Pedido/{nuevoPedido.Id}", nuevoPedido); 
        });

        // 4. Actualizar pedido (PUT)
        app.MapPut("/Pedido/{id}", async (
            [FromServices] IPedidoLogica pedidoLogica, 
            [FromRoute] int id, 
            [FromBody] Pedido pedido) =>
        {
            var pedidoActualizado = await pedidoLogica.ActualizarPedido(id, pedido);
            
            if (pedidoActualizado == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(pedidoActualizado);
        });

        // 5. Eliminar pedido (DELETE)
        app.MapDelete("/Pedido/{id}", async (
            [FromServices] IPedidoLogica pedidoLogica, 
            [FromRoute] int id) =>
        {
            var eliminado = await pedidoLogica.EliminarPedido(id);
            
            if (!eliminado)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });
    }
}