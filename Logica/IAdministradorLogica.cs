using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;



namespace CompumundoApis.Logica;

public interface IAdministradorLogica
{
    public Task<Administrador> ObtenerAdministradorPorId(int id);
    public Task<IEnumerable<Administrador>> ObtenerTodosLosAdministradores();
    public Task<Administrador> CrearAdministrador(Administrador administrador);
    public Task<Administrador> ActualizarAdministrador(int id, Administrador administrador);
    public Task<bool> EliminarAdministrador(int id);
}