namespace Proyecto.ViewModels;

public class EmpleadoListVM
{
    public List<EmpleadosVM> Empleados {get; set;} = new List <EmpleadosVM>(); 
    public string? Filter {get; set;}
}