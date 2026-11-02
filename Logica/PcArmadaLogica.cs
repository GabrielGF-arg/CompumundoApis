using CompumundoApis.Repositorios;
using CompumundoApis.Entidades;


namespace CompumundoApis.Logica;

public class PcArmadaLogica : IPcArmadaLogica
{
    private readonly IPcArmadaRepositorio _pcArmadaRepositorio;

    public PcArmadaLogica(IPcArmadaRepositorio pcArmadaRepositorio)
    {
        _pcArmadaRepositorio = pcArmadaRepositorio;
    }

    public async Task<PcArmada> ObtenerPcArmadaPorId(int id)
    {
        return await _pcArmadaRepositorio.ObtenerPcArmadaPorId(id);
    }

    public async Task<IEnumerable<PcArmada>> ObtenerTodasLasPcsArmadas()
    {
        return await _pcArmadaRepositorio.ObtenerTodasLasPcsArmadas();
    }

    public async Task<PcArmada> CrearPcArmada(PcArmada pcArmada)
    {
        return await _pcArmadaRepositorio.CrearPcArmada(pcArmada);
    }

    public async Task<PcArmada> ActualizarPcArmada(int id, PcArmada pcArmada)
    {
        return await _pcArmadaRepositorio.ActualizarPcArmada(id, pcArmada);
    }

    public async Task<bool> EliminarPcArmada(int id)
    {
        return await _pcArmadaRepositorio.EliminarPcArmada(id);
    }
}