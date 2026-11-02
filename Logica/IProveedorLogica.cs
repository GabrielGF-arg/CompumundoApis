using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;


namespace CompumundoApis.Logica;


public interface IProveedorLogica
{
    public Task<Proveedor> ObtenerProveedorPorId(int id);
    public Task<IEnumerable<Proveedor>> ObtenerTodosLosProveedores();
    public Task<Proveedor> CrearProveedor(Proveedor proveedor);
    public Task<Proveedor> ActualizarProveedor(int id, Proveedor proveedor);
    public Task<bool> EliminarProveedor(int id);
}