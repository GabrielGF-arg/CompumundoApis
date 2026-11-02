using CompumundoApis.Datos;
using CompumundoApis.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CompumundoApis.Endpoints;

public static class TiendaEndpoint
{
    public static void MapTiendaEndpoints(this WebApplication app)
    {
        app.MapPost("/Auth/Registro", async (RegistroRequest request, AppDbContext db) =>
        {
            if (string.IsNullOrWhiteSpace(request.Nombre) || string.IsNullOrWhiteSpace(request.CorreoElectronico) || string.IsNullOrWhiteSpace(request.Contrasenia))
                return Results.BadRequest(new { mensaje = "Nombre, correo y contraseña son obligatorios." });
            var correo = request.CorreoElectronico.Trim().ToLowerInvariant();
            if (await db.Clientes.AnyAsync(c => c.CorreoElectronico.ToLower() == correo))
                return Results.Conflict(new { mensaje = "Ya existe una cuenta con ese correo." });
            var cliente = new Cliente { Nombre = request.Nombre.Trim(), CorreoElectronico = correo, Contrasenia = request.Contrasenia };
            db.Clientes.Add(cliente);
            await db.SaveChangesAsync();
            return Results.Created($"/Cliente/{cliente.Id}", new ClienteSesion(cliente.Id, cliente.Nombre, cliente.CorreoElectronico));
        });

        app.MapPost("/Auth/Login", async (LoginRequest request, AppDbContext db) =>
        {
            var correo = request.CorreoElectronico.Trim().ToLowerInvariant();
            var cliente = await db.Clientes.FirstOrDefaultAsync(c => c.CorreoElectronico.ToLower() == correo && c.Contrasenia == request.Contrasenia);
            return cliente is null
                ? Results.Unauthorized()
                : Results.Ok(new ClienteSesion(cliente.Id, cliente.Nombre, cliente.CorreoElectronico));
        });

        app.MapPost("/Auth/AdminLogin", async (AdminLoginRequest request, AppDbContext db) =>
        {
            var admin = await db.Administradores.FirstOrDefaultAsync(a => a.CodigoAdmin == request.CodigoAdmin && a.ContraseniaAdmin == request.Contrasenia);
            return admin is null ? Results.Unauthorized() : Results.Ok(new { admin.Id, admin.CodigoAdmin });
        });

        app.MapPost("/PcArmada/Configurar", async (ConfigurarPcRequest request, AppDbContext db) =>
        {
            if (string.IsNullOrWhiteSpace(request.Nombre) || request.Componentes.Count == 0)
                return Results.BadRequest(new { mensaje = "Indicá un nombre y al menos un componente." });
            var componentes = await db.Productos.Where(p => request.Componentes.Contains(p.id)).ToListAsync();
            if (componentes.Count != request.Componentes.Distinct().Count()) return Results.BadRequest(new { mensaje = "Hay componentes inválidos." });
            var pc = new PcArmada { Nombre = request.Nombre.Trim(), Descripcion = request.Descripcion?.Trim() ?? "PC configurada por el cliente.", PrecioTotal = componentes.Sum(p => (decimal)p.Precio), Componentes = componentes, IdProducto = 0, IdDetallePedido = 0 };
            db.PcArmadas.Add(pc); await db.SaveChangesAsync();
            return Results.Created($"/PcArmada/{pc.PcArmadaId}", pc);
        });

        app.MapPost("/Compra", async (CompraRequest request, AppDbContext db) =>
        {
            var cliente = await db.Clientes.FindAsync(request.ClienteId);
            if (cliente is null) return Results.NotFound(new { mensaje = "Cliente no encontrado." });
            if (request.Items is null || request.Items.Count == 0) return Results.BadRequest(new { mensaje = "El carrito está vacío." });
            var productos = await db.Productos.Where(p => request.Items.Select(i => i.ProductoId).Contains(p.id)).ToListAsync();
            if (productos.Count != request.Items.Select(i => i.ProductoId).Distinct().Count()) return Results.BadRequest(new { mensaje = "Uno de los productos no existe." });
            if (request.Items.Any(i => i.Cantidad < 1) || productos.Any(p => request.Items.First(i => i.ProductoId == p.id).Cantidad > p.Stock)) return Results.BadRequest(new { mensaje = "No hay stock suficiente." });

            var cuenta = new CuentaCliente { ClienteId = cliente.Id, Facturacion = request.Direccion.Facturacion, Pais = request.Direccion.Pais, provincia = request.Direccion.Provincia, Ciudad = request.Direccion.Ciudad, CodigoPostal = request.Direccion.CodigoPostal, Calle = request.Direccion.Calle, NumeroCalle = request.Direccion.NumeroCalle };
            var pedido = new Pedido { ClienteId = cliente.Id, Remitente = cliente.Nombre, IdAdministrador = 0, FechaPedido = DateTime.UtcNow, Estado = Pedido.EstadoPedido.Pendiente };
            foreach (var item in request.Items)
            {
                var producto = productos.First(p => p.id == item.ProductoId);
                producto.Stock -= item.Cantidad;
                pedido.Detalles.Add(new DetallePedido { IdProducto = producto.id, Cantidad = item.Cantidad, PrecioTotal = (decimal)producto.Precio * item.Cantidad });
            }
            var subtotal = pedido.Detalles.Sum(d => d.PrecioTotal);
            var impuesto = Math.Round(subtotal * 0.21m, 2);
            pedido.Total = subtotal + impuesto;
            db.CuentaClientes.Add(cuenta);
            db.Pedidos.Add(pedido);
            await db.SaveChangesAsync();
            return Results.Created($"/Pedido/{pedido.Id}", new { pedido.Id, pedido.Total, Subtotal = subtotal, Impuesto = impuesto, Estado = pedido.Estado.ToString(), CuentaClienteId = cuenta.CuentaClienteId });
        });

        app.MapGet("/Cliente/{clienteId:int}/Pedidos", async (int clienteId, AppDbContext db) =>
        {
            var pedidos = await db.Pedidos.Where(p => p.ClienteId == clienteId).Include(p => p.Detalles).OrderByDescending(p => p.FechaPedido)
                .Select(p => new { p.Id, p.FechaPedido, Estado = p.Estado.ToString(), p.Total, Detalles = p.Detalles.Select(d => new { d.DetallePedidoId, d.IdProducto, d.Cantidad, d.PrecioTotal }) }).ToListAsync();
            return Results.Ok(pedidos);
        });
    }

    public record RegistroRequest(string Nombre, string CorreoElectronico, string Contrasenia);
    public record LoginRequest(string CorreoElectronico, string Contrasenia);
    public record AdminLoginRequest(string CodigoAdmin, string Contrasenia);
    public record ConfigurarPcRequest(string Nombre, string? Descripcion, List<int> Componentes);
    public record ClienteSesion(int Id, string Nombre, string CorreoElectronico);
    public record ItemCompra(int ProductoId, int Cantidad);
    public record DireccionCompra(string Facturacion, string Pais, string Provincia, string Ciudad, string CodigoPostal, string Calle, string NumeroCalle);
    public record CompraRequest(int ClienteId, DireccionCompra Direccion, List<ItemCompra> Items);
}
