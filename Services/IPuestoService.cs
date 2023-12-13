using Proyecto.Models;
using Proyecto.ViewModels;

namespace Proyecto.Services;

public interface IPuestoService{
    Task<List<Puesto>> GetAll(string filter);
    Task Update (Puesto puesto);
    Task Delete(int Id);
    Task Create (Puesto puesto);
    Task<Puesto> GetById(int? id);
    Task<List<Puesto>> GetAllPuestos();
   
 
    

}

