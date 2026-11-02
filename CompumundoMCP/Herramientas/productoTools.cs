using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;
using System.Net.Http;

namespace CompumundoMCP.Herramientas;

[McpServerToolType]
public static class ProductoTools
{
    // Configuración para interpretar los productos recibidos
    private static readonly JsonSerializerOptions opciones = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    // 1. BUSCAR PRODUCTOS
    [McpServerTool]
    [Description("Busca productos de Compumundo por nombre, marca, modelo, precio máximo o disponibilidad de stock.")]
    public static async Task<string> BuscarProductos(
        IHttpClientFactory factory,
        [Description("Nombre del producto que se desea buscar.")] string? nombre = null,
        [Description("Marca del producto.")] string? marca = null,
        [Description("Modelo del producto.")] string? modelo = null,
        [Description("Precio máximo permitido.")] float? precioMaximo = null,
        [Description("Indica si solamente se buscan productos con stock.")] bool soloConStock = false)
    {
        var cliente = factory.CreateClient("Compumundo");

        var respuesta = await cliente.GetAsync("/Producto");

        if (!respuesta.IsSuccessStatusCode)
        {
            return "No se pudieron obtener los productos de Compumundo.";
        }

        var contenido = await respuesta.Content.ReadAsStringAsync();

        var productos = JsonSerializer.Deserialize<List<ProductoDto>>(
            contenido, opciones);

        if (productos == null || productos.Count == 0)
        {
            return "No hay productos registrados.";
        }

        var resultados = new List<ProductoDto>();

        foreach (var producto in productos)
        {
            if (!string.IsNullOrWhiteSpace(nombre) &&
                !producto.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                continue;

            if (!string.IsNullOrWhiteSpace(marca) &&
                !producto.Marca.Contains(marca, StringComparison.OrdinalIgnoreCase))
                continue;

            if (!string.IsNullOrWhiteSpace(modelo) &&
                !producto.Modelo.Contains(modelo, StringComparison.OrdinalIgnoreCase))
                continue;

            if (precioMaximo.HasValue && producto.Precio > precioMaximo.Value)
                continue;

            if (soloConStock && producto.Stock <= 0)
                continue;

            resultados.Add(producto);
        }

        if (resultados.Count == 0)
        {
            return "No se encontraron productos que coincidan con la búsqueda.";
        }

        return JsonSerializer.Serialize(resultados, opciones);
    }

    // 2. CONSULTAR PRODUCTO POR ID
    [McpServerTool]
    [Description("Consulta la información completa de un producto de Compumundo utilizando su ID.")]
    public static async Task<string> ConsultarProducto(
        IHttpClientFactory factory,
        [Description("Identificador del producto que se desea consultar.")] int id)
    {
        var cliente = factory.CreateClient("Compumundo");

        var respuesta = await cliente.GetAsync($"/Producto/{id}");

        if (respuesta.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return $"No existe un producto con el ID {id}.";
        }

        if (!respuesta.IsSuccessStatusCode)
        {
            return "No se pudo consultar el producto.";
        }

        return await respuesta.Content.ReadAsStringAsync();
    }

    // 3. COMPARAR PRODUCTOS
    [McpServerTool]
    [Description("Compara varios productos de Compumundo utilizando sus identificadores.")]
    public static async Task<string> CompararProductos(
        IHttpClientFactory factory,
        [Description("Identificadores de los productos separados por comas. Ejemplo: 1,2,3")] string ids)
    {
        var cliente = factory.CreateClient("Compumundo");

        var identificadores = ids.Split(',');

        var productos = new List<ProductoDto>();

        foreach (var identificador in identificadores)
        {
            if (!int.TryParse(identificador.Trim(), out int id))
            {
                return "Uno de los identificadores ingresados no es válido.";
            }

            var respuesta = await cliente.GetAsync($"/Producto/{id}");

            if (!respuesta.IsSuccessStatusCode)
            {
                return $"No se pudo encontrar el producto con ID {id}.";
            }

            var contenido = await respuesta.Content.ReadAsStringAsync();

            var producto = JsonSerializer.Deserialize<ProductoDto>(
                contenido, opciones);

            if (producto != null)
            {
                productos.Add(producto);
            }
        }

        return JsonSerializer.Serialize(productos, opciones);
    }

    // Modelo utilizado para recibir los datos de la API
    public class ProductoDto
    {
        public int id { get; set; }
        public string Nombre { get; set; } = "";
        public float Precio { get; set; }
        public int Stock { get; set; }
        public string Marca { get; set; } = "";
        public string Modelo { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string? ImagenUrl { get; set; }
    }
}