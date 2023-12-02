using Proyecto.Data;
using Proyecto.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto.ViewModels;

namespace Proyecto.Services;

public class SectorService : ISectorService
{
    private readonly EmpleadosPuestosContext _context;

      public SectorService (EmpleadosPuestosContext context)
        {
            _context = context;
        }
    public async Task Create(Sector sector)
    {
        _context.Add(sector);
        await _context.SaveChangesAsync();
    }

    


    public async Task Delete(int Id)
    {
       var sector= await _context.Sector.FindAsync(Id);
       if(sector !=null)
       {
           _context.Sector.Remove(sector);
       }

       await _context.SaveChangesAsync();
    }

  

    public async Task<List<Sector>> GetAll(string filter)
    {
        
        
            var query =from sector in _context.Sector select sector; 
            if (!String.IsNullOrEmpty(filter))
            {
               query = query
               .Where(x=> x.Name.ToLower().Contains(filter.ToLower()) || 
               x.Description.ToLower().Contains(filter.ToLower()));
            }
            return await query.ToListAsync();
        
    }

    public async Task<List<Sector>> GetAllEmpleados()
    {
        return await _context.Sector.ToListAsync();
    }

    public async Task<Sector?> GetById(int? id)
    {
        if (id == null || _context.Sector == null)
        {
            return null;
        }

        return await _context.Sector
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    
      public async Task Update(Sector sector)
    {
        _context.Update(sector);
        await _context.SaveChangesAsync();
    }


    
}


