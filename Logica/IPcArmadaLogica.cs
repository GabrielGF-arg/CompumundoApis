using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;



namespace CompumundoApis.Logica;

public interface IPcArmadaLogica
{
    public Task<PcArmada> ObtenerPcArmadaPorId(int id);
    public Task<IEnumerable<PcArmada>> ObtenerTodasLasPcsArmadas();
    public Task<PcArmada> CrearPcArmada(PcArmada pcArmada);
    public Task<PcArmada> ActualizarPcArmada(int id, PcArmada pcArmada);
    public Task<bool> EliminarPcArmada(int id);
}