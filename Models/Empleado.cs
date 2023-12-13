namespace Proyecto.Models;


public class Empleado{
    public int Id {get; set;}
    public int PuestoId {get; set;}
    public string? Nombre {get;set;}
    public string? Apellido {get; set;}
    public int Edad {get; set;}
    public int Sueldo{get; set;}
    public int Ambiguedad {get;set;}
    public static DateTime date {get;set;} 
    
    public virtual ICollection<Puesto> Puestos {get;set;}
    
}
