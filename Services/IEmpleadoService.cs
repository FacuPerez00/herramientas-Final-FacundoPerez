using Proyecto.Models;
using Proyecto.ViewModels;

namespace Proyecto.Services;

public interface IEmpleadoService{
    Task<List<Empleado>> GetAll(string filter);
    Task Update (Empleado empleado);
    Task Delete(int Id);
    Task Create (Empleado empleado);
    Task<Empleado> GetById(int? id);
    Task<List<Empleado>> GetAllEmpleados();
   
 
    

}

