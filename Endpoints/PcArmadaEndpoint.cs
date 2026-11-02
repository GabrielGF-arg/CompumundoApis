using CompumundoApis.Entidades;
using CompumundoApis.Logica;
using Microsoft.AspNetCore.Mvc;



namespace CompumundoApis.Endpoints;

public static class PcArmadaEndpoint
{
   public static void MapPcArmadaEndpoints(this WebApplication app)
    {
        // 1. Obtener todas las PCs armadas (GET)
        app.MapGet("/PcArmada", async (
            [FromServices] IPcArmadaLogica pcArmadaLogica) =>
        {
            var pcs = await pcArmadaLogica.ObtenerTodasLasPcsArmadas();
            return Results.Ok(pcs);
        });

        // 2. Obtener PC armada por ID (GET)
        app.MapGet("/PcArmada/{id}", async (
            [FromServices] IPcArmadaLogica pcArmadaLogica, 
            [FromRoute] int id) =>
        {
            var pc = await pcArmadaLogica.ObtenerPcArmadaPorId(id);
            
            if (pc == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(pc);
        });

        // 3. Crear PC armada (POST)
        app.MapPost("/PcArmada", async (
            [FromServices] IPcArmadaLogica pcArmadaLogica, 
            [FromBody] PcArmada pcArmada) =>
        {
            var nuevaPc = await pcArmadaLogica.CrearPcArmada(pcArmada);
            
            return Results.Created($"/PcArmada/{nuevaPc.PcArmadaId}", nuevaPc); 
        });

        // 4. Actualizar PC armada (PUT)
        app.MapPut("/PcArmada/{id}", async (
            [FromServices] IPcArmadaLogica pcArmadaLogica, 
            [FromRoute] int id, 
            [FromBody] PcArmada pcArmada) =>
        {
            var pcActualizada = await pcArmadaLogica.ActualizarPcArmada(id, pcArmada);
            
            if (pcActualizada == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(pcActualizada);
        });

        // 5. Eliminar PC armada (DELETE)
        app.MapDelete("/PcArmada/{id}", async (
            [FromServices] IPcArmadaLogica pcArmadaLogica, 
            [FromRoute] int id) =>
        {
            var eliminado = await pcArmadaLogica.EliminarPcArmada(id);
            
            if (!eliminado)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });
    }
}