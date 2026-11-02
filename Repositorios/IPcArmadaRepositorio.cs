using CompumundoApis.Entidades;

namespace CompumundoApis.Repositorios;
public interface IPcArmadaRepositorio
{
    Task<PcArmada> ObtenerPcArmadaPorId(int id);
    Task<IEnumerable<PcArmada>> ObtenerTodasLasPcsArmadas();
    Task<PcArmada> CrearPcArmada(PcArmada pcArmada);
    Task<PcArmada> ActualizarPcArmada(int id, PcArmada pcArmada);
    Task<bool> EliminarPcArmada(int id);
}