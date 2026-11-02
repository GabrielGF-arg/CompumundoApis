using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;


namespace CompumundoApis.Logica;
public class CuentaClienteLogica : ICuentaClienteLogica
{
    private readonly ICuentaClienteRepositorio _cuentaClienteRepositorio;

    public CuentaClienteLogica(ICuentaClienteRepositorio cuentaClienteRepositorio)
    {
        _cuentaClienteRepositorio = cuentaClienteRepositorio;
    }

    public Task<CuentaCliente> CrearCuentaCliente(CuentaCliente cuentaCliente)
    {
        return _cuentaClienteRepositorio.CrearCuentaCliente(cuentaCliente);
    }

    public Task<bool> EliminarCuentaCliente(int id)
    {
        return _cuentaClienteRepositorio.EliminarCuentaCliente(id);
    }

    public Task<IEnumerable<CuentaCliente>> ObtenerTodasLasCuentasClientes()
    {
        return _cuentaClienteRepositorio.ObtenerTodasLasCuentasClientes();
    }

    public Task<CuentaCliente> ObtenerCuentaClientePorId(int id)
    {
        return _cuentaClienteRepositorio.ObtenerCuentaClientePorId(id);
    }

    public Task<CuentaCliente> ActualizarCuentaCliente(int id, CuentaCliente cuentaCliente)
    {
        return _cuentaClienteRepositorio.ActualizarCuentaCliente(id, cuentaCliente);
    }
}