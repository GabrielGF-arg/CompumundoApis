using CompumundoApis.Datos;
using Microsoft.EntityFrameworkCore;
using CompumundoApis.Entidades;

namespace CompumundoApis.Repositorios;
public class PcArmadaRepositorio : IPcArmadaRepositorio
{
    private readonly AppDbContext _context;

    public PcArmadaRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PcArmada> ObtenerPcArmadaPorId(int id)
    {
        return await _context.PcArmadas.FindAsync(id);
    }

    public async Task<IEnumerable<PcArmada>> ObtenerTodasLasPcsArmadas()
    {
        return await _context.PcArmadas.ToListAsync();
    }

    public async Task<PcArmada> CrearPcArmada(PcArmada pcArmada)
    {
        _context.PcArmadas.Add(pcArmada);
        await _context.SaveChangesAsync();
        return pcArmada;
    }

    public async Task<PcArmada> ActualizarPcArmada(int id, PcArmada pcArmada)
    {
        var existingPcArmada = await _context.PcArmadas.FindAsync(id);
        if (existingPcArmada == null)
        {
            return null;
        }

        // Actualizar las propiedades del objeto existente con los valores del objeto proporcionado
        existingPcArmada.Nombre = pcArmada.Nombre;
        existingPcArmada.Descripcion = pcArmada.Descripcion;
        existingPcArmada.PrecioTotal = pcArmada.PrecioTotal;

        await _context.SaveChangesAsync();
        return existingPcArmada;
    }

    public async Task<bool> EliminarPcArmada(int id)
    {
        var pcArmada = await _context.PcArmadas.FindAsync(id);
        if (pcArmada == null)
        {
            return false;
        }

        _context.PcArmadas.Remove(pcArmada);
        await _context.SaveChangesAsync();
        return true;
    }
}