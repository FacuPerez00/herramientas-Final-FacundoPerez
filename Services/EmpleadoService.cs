using Proyecto.Data;
using Proyecto.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto.ViewModels;

namespace Proyecto.Services;

public class EmpleadoService : IEmpleadoService
{
    private readonly EmpleadosPuestosContext _context;

      public EmpleadoService(EmpleadosPuestosContext context)
        {
            _context = context;
        }
    public async Task Create(Empleado empleado)
    {
        _context.Add(empleado);
        await _context.SaveChangesAsync();
    }

    


    public async Task Delete(int Id)
    {
       var empleado= await _context.Empleados.FindAsync(Id);
       if(empleado !=null)
       {
           _context.Empleados.Remove(empleado);
       }

       await _context.SaveChangesAsync();
    }

  

    public async Task<List<Empleado>> GetAll(string filter)
    {
        
        
            var query =from empleados in _context.Empleados select empleados; 
            if (!String.IsNullOrEmpty(filter))
            {
               query = query
               .Where(x=> x.Nombre.ToLower().Contains(filter.ToLower()) || 
               x.Apellido.ToLower().Contains(filter.ToLower()));
            }
            return await query.ToListAsync();
        
    }

    public async Task<List<Empleado>> GetAllEmpleados()
    {
        return await _context.Empleados.ToListAsync();
    }

    public async Task<Empleado?> GetById(int? id)
    {
        if (id == null || _context.Empleados == null)
        {
            return null;
        }

        return await _context.Empleados
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task Update(Empleado empleado)
    {
        _context.Update(empleado);
        await _context.SaveChangesAsync();
    }


    
}


