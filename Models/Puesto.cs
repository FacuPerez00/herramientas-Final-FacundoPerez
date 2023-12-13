namespace Proyecto.Models;

public class Puesto{
    public int Id {get; set;}
    
    public string Nombre {get;set;}
    public int? SectorId {get;set;}

    public virtual ICollection<Empleado>? Empleados {get; set;}
    public virtual Sector Sector {get;set;}
}