using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;


namespace CompumundoApis.Logica;


public class AdministradorLogica : IAdministradorLogica
{
    private readonly IAdministradorRepositorio _administradorRepositorio;

    public AdministradorLogica(IAdministradorRepositorio administradorRepositorio)
    {
        _administradorRepositorio = administradorRepositorio;
    }

    public Task<Administrador> CrearAdministrador(Administrador administrador)
    {
        return _administradorRepositorio.CrearAdministrador(administrador);
    }

    public Task<Administrador> ObtenerAdministradorPorId(int id)
    {
        return _administradorRepositorio.ObtenerAdministradorPorId(id);
    }

    public Task<IEnumerable<Administrador>> ObtenerTodosLosAdministradores()
    {
        return _administradorRepositorio.ObtenerTodosLosAdministradores();
    }

    public Task<Administrador> ActualizarAdministrador(int id, Administrador administrador)
    {
        return _administradorRepositorio.ActualizarAdministrador(id, administrador);
    }

    public Task<bool> EliminarAdministrador(int id)
    {
        return _administradorRepositorio.EliminarAdministrador(id);
    }
}