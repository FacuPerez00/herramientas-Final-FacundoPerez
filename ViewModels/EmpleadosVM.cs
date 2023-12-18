using System.ComponentModel.DataAnnotations;

namespace Proyecto.ViewModels;


public class EmpleadosVM{
    public int Id {get; set;}
    public string Nombre {get;set;}
    public string Apellido {get; set;}
    public int Edad {get; set;}
    public int Sueldo{get; set;}
    public int Ambiguedad {get;set;}
    public DateTime FechaAlta {get;set;}
    public DateTime FechaBaja {get; set;}
    public bool Activo {get; set;}
}
   