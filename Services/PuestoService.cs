using Proyecto.Data;
using Proyecto.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Proyecto.Services;

public class PuestoService : IPuestoService
{
    private readonly EmpleadosPuestosContext _context;

      public PuestoService(EmpleadosPuestosContext context)
        {
            _context = context;
        }
    public async Task Create(Puesto puesto)
    {
        DateTime fechaAlta=DateTime.Now;
        _context.Add(puesto);
        await _context.SaveChangesAsync();
    }

    


    public async Task Delete(int Id)
    {
       var puesto= await _context.Puestos.FindAsync(Id);
       if(puesto !=null)
       {
           _context.Puestos.Remove(puesto);
       }

       await _context.SaveChangesAsync();
    }

  

    public async Task<List<Puesto>> GetAll(string filter)
    {
        
        
            var query =from puestos in _context.Puestos select puestos; 
            if (!String.IsNullOrEmpty(filter))
            {
               query = query
               .Where(x=> x.Nombre.ToLower().Contains(filter.ToLower()));
            }
            return await query.ToListAsync();
        
    }

    public async Task<List<Puesto>> GetAllPuestos()
    {
        return await _context.Puestos.ToListAsync();
    }

    public async Task<Puesto?> GetById(int? id)
    {
        if (id == null || _context.Puestos == null)
        {
            return null;
        }

        return await _context.Puestos
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task Update(Puesto puesto)
    {
        _context.Update(puesto);
        await _context.SaveChangesAsync();
    }

    public async Task Edit()
    {
      
    }


    
}

