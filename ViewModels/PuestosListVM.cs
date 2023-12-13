using System.ComponentModel.DataAnnotations;

namespace Proyecto.ViewModels;

public class PuestosListVM
{    
    public List<PuestosVM> Puestos {get; set;} = new List <PuestosVM>(); 
    public string? Filter {get; set;}
}