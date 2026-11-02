using CompumundoApis.Datos;
using CompumundoApis.Repositorios;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using CompumundoApis.Endpoints;
using CompumundoApis.Logica;
using Prometheus;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IAdministradorRepositorio, AdministradorRepositorio>();
builder.Services.AddScoped<ICuentaClienteRepositorio, CuentaClienteRepositorio>();
builder.Services.AddScoped<IDetallePedidoRepositorio, DetallePedidoRepositorio>();
builder.Services.AddScoped<IProveedorRepositorio, ProveedorRepositorio>();
builder.Services.AddScoped<IPcArmadaRepositorio, PcArmadaRepositorio>();
builder.Services.AddScoped<IVentasRepositorio, VentasRepositorio>();

builder.Services.AddScoped<IProductoLogica, ProductoLogica>();
builder.Services.AddScoped<IAdministradorLogica, AdministradorLogica>();
builder.Services.AddScoped<IClienteLogica, ClienteLogica>();
builder.Services.AddScoped<ICuentaClienteLogica, CuentaClienteLogica>();
builder.Services.AddScoped<IDetallePedidoLogica, DetallePedidoLogica>();
builder.Services.AddScoped<IPcArmadaLogica, PcArmadaLogica>();
builder.Services.AddScoped<IPedidoLogica, PedidoLogica>();
builder.Services.AddScoped<IProductoLogica, ProductoLogica>();
builder.Services.AddScoped<IProveedorLogica, ProveedorLogica>();
builder.Services.AddScoped<IVentasLogica, VentasLogica>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// Habilitar el monitoreo de solicitudes HTTP
app.UseHttpMetrics();


app.MapAdministradorEndpoints();
app.MapClienteEndpoints();
app.MapCuentaClienteEndpoints();
app.MapDetallePedidoEndpoints();
app.MapPcArmadaEndpoints();
app.MapPedidoEndpoints();
app.MapProductoEndpoints();
app.MapProveedorEndpoints();
app.MapVentasEndpoints();
app.MapTiendaEndpoints();
// Endpoint desde el que Prometheus recopilará las métricas
app.MapMetrics();
app.Run();


