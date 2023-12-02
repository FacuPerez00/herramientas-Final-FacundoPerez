using Proyecto.Models;
using Proyecto.ViewModels;

namespace Proyecto.Services;

public interface ISectorService{
    Task<List<Sector>> GetAll(string filter);
    Task Update (Sector sector);
    Task Delete(int Id);
    Task Create (Sector sector);
    Task<Sector> GetById(int? id);
    Task<List<Sector>> GetAllEmpleados();
   
}

