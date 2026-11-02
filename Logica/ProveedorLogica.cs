using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;

namespace CompumundoApis.Logica;
public class ProveedorLogica : IProveedorLogica
{
    private readonly IProveedorRepositorio _proveedorRepositorio;

    public ProveedorLogica(IProveedorRepositorio proveedorRepositorio)
    {
        _proveedorRepositorio = proveedorRepositorio;
    }

    public async Task<Proveedor> ObtenerProveedorPorId(int id)
    {
        return await _proveedorRepositorio.ObtenerProveedorPorId(id);
    }

    public async Task<IEnumerable<Proveedor>> ObtenerTodosLosProveedores()
    {
        return await _proveedorRepositorio.ObtenerTodosLosProveedores();
    }

    public async Task<Proveedor> CrearProveedor(Proveedor proveedor)
    {
        return await _proveedorRepositorio.CrearProveedor(proveedor);
    }

    public async Task<Proveedor> ActualizarProveedor(int id, Proveedor proveedor)
    {
        return await _proveedorRepositorio.ActualizarProveedor(id, proveedor);
    }

    public async Task<bool> EliminarProveedor(int id)
    {
        return await _proveedorRepositorio.EliminarProveedor(id);
    }
}