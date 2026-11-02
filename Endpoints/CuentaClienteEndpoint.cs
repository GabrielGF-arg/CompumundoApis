using CompumundoApis.Entidades;
using CompumundoApis.Logica;
using Microsoft.AspNetCore.Mvc;


namespace CompumundoApis.Endpoints;
public static class CuentaClienteEndpoint
{
   public static void MapCuentaClienteEndpoints(this WebApplication app)
    {
        // 1. Obtener todas las cuentas de clientes (GET)
        app.MapGet("/CuentaCliente", async (
            [FromServices] ICuentaClienteLogica cuentaClienteLogica) =>
        {
            var cuentas = await cuentaClienteLogica.ObtenerTodasLasCuentasClientes();
            return Results.Ok(cuentas);
        });

        // 2. Obtener cuenta de cliente por ID (GET)
        app.MapGet("/CuentaCliente/{id}", async (
            [FromServices] ICuentaClienteLogica cuentaClienteLogica, 
            [FromRoute] int id) =>
        {
            var cuenta = await cuentaClienteLogica.ObtenerCuentaClientePorId(id);
            
            if (cuenta == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(cuenta);
        });

        // 3. Crear cuenta de cliente (POST)
        app.MapPost("/CuentaCliente", async (
            [FromServices] ICuentaClienteLogica cuentaClienteLogica, 
            [FromBody] CuentaCliente cuentaCliente) =>
        {
            var nuevaCuenta = await cuentaClienteLogica.CrearCuentaCliente(cuentaCliente);
            
            return Results.Created($"/CuentaCliente/{nuevaCuenta.CuentaClienteId}", nuevaCuenta); 
        });

        // 4. Actualizar cuenta de cliente (PUT)
        app.MapPut("/CuentaCliente/{id}", async (
            [FromServices] ICuentaClienteLogica cuentaClienteLogica, 
            [FromRoute] int id, 
            [FromBody] CuentaCliente cuentaCliente) =>
        {
            var cuentaActualizada = await cuentaClienteLogica.ActualizarCuentaCliente(id, cuentaCliente);
            
            if (cuentaActualizada == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(cuentaActualizada);
        });

        // 5. Eliminar cuenta de cliente (DELETE)
        app.MapDelete("/CuentaCliente/{id}", async (
            [FromServices] ICuentaClienteLogica cuentaClienteLogica, 
            [FromRoute] int id) =>
        {
            var eliminado = await cuentaClienteLogica.EliminarCuentaCliente(id);
            
            if (!eliminado)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });
    }
}