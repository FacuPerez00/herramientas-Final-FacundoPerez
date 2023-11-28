namespace Proyecto.Models;

public class Sector{
    public int Id {get; set;}
    
    public string Name {get;set;}
    public string Description {get;set;}
    
    public virtual ICollection<Puesto> Puestos {get; set;}
}