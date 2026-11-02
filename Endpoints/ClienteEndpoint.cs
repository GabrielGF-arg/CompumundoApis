using CompumundoApis.Entidades;
using CompumundoApis.Logica;
using Microsoft.AspNetCore.Mvc;


namespace CompumundoApis.Endpoints;

public static class ClienteEndpoint
{
   public static void MapClienteEndpoints(this WebApplication app)
    {
        // 1. Obtener todos los clientes (GET)
        app.MapGet("/Cliente", async (
            [FromServices] IClienteLogica clienteLogica) =>
        {
            var clientes = await clienteLogica.ObtenerTodosLosClientes();
            return Results.Ok(clientes);
        });

        // 2. Obtener cliente por ID (GET)
        app.MapGet("/Cliente/{id}", async (
            [FromServices] IClienteLogica clienteLogica, 
            [FromRoute] int id) =>
        {
            var cliente = await clienteLogica.ObtenerClientePorId(id);
            
            if (cliente == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(cliente);
        });

        // 3. Crear cliente (POST)
        app.MapPost("/Cliente", async (
            [FromServices] IClienteLogica clienteLogica, 
            [FromBody] Cliente cliente) =>
        {
            var nuevoCliente = await clienteLogica.CrearCliente(cliente);
            
            return Results.Created($"/Cliente/{nuevoCliente.Id}", nuevoCliente); 
        });

        // 4. Actualizar cliente (PUT)
        app.MapPut("/Cliente/{id}", async (
            [FromServices] IClienteLogica clienteLogica, 
            [FromRoute] int id, 
            [FromBody] Cliente cliente) =>
        {
            var clienteActualizado = await clienteLogica.ActualizarCliente(id, cliente);
            
            if (clienteActualizado == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(clienteActualizado);
        });

        // 5. Eliminar cliente (DELETE)
        app.MapDelete("/Cliente/{id}", async (
            [FromServices] IClienteLogica clienteLogica, 
            [FromRoute] int id) =>
        {
            var eliminado = await clienteLogica.EliminarCliente(id);
            
            if (!eliminado)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });
    }
}