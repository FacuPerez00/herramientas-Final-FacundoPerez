namespace Proyecto.ViewModels;

public class EmpleadosListVM
{
    public List<EmpleadosVM> Empleados {get; set;} = new List <EmpleadosVM>(); 
    public string? Filter {get; set;}
}