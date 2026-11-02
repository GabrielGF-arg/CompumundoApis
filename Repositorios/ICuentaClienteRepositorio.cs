using CompumundoApis.Entidades;


namespace CompumundoApis.Repositorios;

public interface ICuentaClienteRepositorio
{
    public  Task<CuentaCliente> ObtenerCuentaClientePorId(int id);
    public  Task<IEnumerable<CuentaCliente>> ObtenerTodasLasCuentasClientes();
    public Task<CuentaCliente> CrearCuentaCliente(CuentaCliente cuentaCliente);
    public Task<CuentaCliente> ActualizarCuentaCliente(int id, CuentaCliente cuentaCliente);
    public Task<bool> EliminarCuentaCliente(int id);
}