using CompumundoApis.Datos;
using CompumundoApis.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace CompumundoApis.Repositorios;
public class AdministradorRepositorio : IAdministradorRepositorio
{
    private readonly AppDbContext _context;

    public AdministradorRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Administrador> CrearAdministrador(Administrador administrador)
    {
        _context.Administradores.Add(administrador);
        await _context.SaveChangesAsync();
        return administrador;
    }

    public async Task<Administrador> ObtenerAdministradorPorId(int id)
    {
        return await _context.Administradores.FindAsync(id);
    }
    public async Task<IEnumerable<Administrador>> ObtenerTodosLosAdministradores()
    {
        return await _context.Administradores.ToListAsync();
    }

    public async Task<Administrador> ActualizarAdministrador(int id,Administrador administrador)
    {
        _context.Administradores.Update(administrador);
        await _context.SaveChangesAsync();
        return administrador;
    }
    public async Task<bool> EliminarAdministrador(int id)
    {
        var administrador = await _context.Administradores.FindAsync(id);
        if (administrador == null)
        {
            return false;
        }
        _context.Administradores.Remove(administrador);
        await _context.SaveChangesAsync();
        return true;
    }
}