namespace Proyecto.Models;

public class Sector{
    public int Id {get; set;}
    
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    
    public virtual ICollection<Puesto> Puestos {get; set;}
}