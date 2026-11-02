using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

// Evitamos que los mensajes de consola interfieran
// con la comunicación del protocolo MCP.
builder.Logging.AddConsole(options =>
{
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

// Configuramos la conexión con la API de Compumundo.
builder.Services.AddHttpClient("Compumundo", cliente =>
{
    cliente.BaseAddress = new Uri("http://localhost:5080");
});

// Configuramos el servidor MCP.
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

// Iniciamos el servidor.
await builder.Build().RunAsync();