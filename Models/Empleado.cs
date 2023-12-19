namespace Proyecto.Models;


public class Empleado{
    //primer relacion: Un empleado con un PuestoId
    public int Id {get; set;}
    public int PuestoId {get; set;}
    public string? Nombre {get;set;}
    public string? Apellido {get; set;}
    public int Edad {get; set;}
    public int Sueldo{get; set;}
    public int Ambiguedad {get;set;}
    public DateTime FechaAlta {get;set;}
    public DateTime FechaBaja {get; set;}
    public bool Activo {get; set;}
    //tercer relacion un Empleadoid con un PuestoId
    public virtual ICollection<Puesto> Puestos {get;set;}
    
}
