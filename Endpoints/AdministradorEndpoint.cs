using CompumundoApis.Entidades;
using CompumundoApis.Logica;
using Microsoft.AspNetCore.Mvc;

namespace CompumundoApis.Endpoints;

public static class AdministradorEndpoint
{
   public static void MapAdministradorEndpoints(this WebApplication app)
    {
        
        app.MapGet("/Administrador", async (
            [FromServices] IAdministradorLogica administradorLogica) =>
        {
            var administradores = await administradorLogica.ObtenerTodosLosAdministradores();
            return Results.Ok(administradores);
        });

        
        app.MapGet("/Administrador/{id}", async (
            [FromServices] IAdministradorLogica administradorLogica, 
            [FromRoute] int id) =>
        {
            var administrador = await administradorLogica.ObtenerAdministradorPorId(id);
            
            if (administrador == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(administrador);
        });

       
        app.MapPost("/Administrador", async (
            [FromServices] IAdministradorLogica administradorLogica, 
            [FromBody] Administrador administrador) =>
        {
            var nuevoAdministrador = await administradorLogica.CrearAdministrador(administrador);
            
            // Buena práctica: devolver 201 Created cuando se inserta algo nuevo
            return Results.Created($"/Administrador/{nuevoAdministrador.Id}", nuevoAdministrador); 
        });

        
        app.MapPut("/Administrador/{id}", async (
            [FromServices] IAdministradorLogica administradorLogica, 
            [FromRoute] int id, 
            [FromBody] Administrador administrador) =>
        {
            var adminActualizado = await administradorLogica.ActualizarAdministrador(id, administrador);
            
            if (adminActualizado == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(adminActualizado);
        });

        
        app.MapDelete("/Administrador/{id}", async (
            [FromServices] IAdministradorLogica administradorLogica, 
            [FromRoute] int id) =>
        {
            var eliminado = await administradorLogica.EliminarAdministrador(id);
            
            if (!eliminado) // Si devolvió false, asumimos que no existía
            {
                return Results.NotFound();
            }

            return Results.NoContent(); // 204 NoContent es el estándar para un Delete exitoso
        });
    }    
}