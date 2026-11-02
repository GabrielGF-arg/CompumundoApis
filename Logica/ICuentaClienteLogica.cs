using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;



namespace CompumundoApis.Logica;

public interface ICuentaClienteLogica
{
        public Task<CuentaCliente> CrearCuentaCliente(CuentaCliente cuentaCliente);
        public Task<CuentaCliente> ObtenerCuentaClientePorId(int id);   
        public Task<IEnumerable<CuentaCliente>> ObtenerTodasLasCuentasClientes();
        public Task<CuentaCliente> ActualizarCuentaCliente(int id, CuentaCliente cuentaCliente);
        public Task<bool> EliminarCuentaCliente(int id);



}