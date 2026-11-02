using CompumundoApis.Entidades;

namespace CompumundoApis.Repositorios;
public interface IAdministradorRepositorio
{
    Task<Administrador> ObtenerAdministradorPorId(int id);
    Task<IEnumerable<Administrador>> ObtenerTodosLosAdministradores();
    Task<Administrador> CrearAdministrador(Administrador administrador);
    Task<Administrador> ActualizarAdministrador(int id, Administrador administrador);
    Task<bool> EliminarAdministrador(int id);
}