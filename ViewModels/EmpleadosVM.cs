using System.ComponentModel.DataAnnotations;

namespace Proyecto.ViewModels;


public class EmpleadosVM{
    public int Id {get; set;}
    public string Nombre {get;set;}
    public string Apellido {get; set;}
    public int Edad {get; set;}
    public int Sueldo{get; set;}
    public int Ambiguedad {get;set;}
    //public DateTime Now {get;}
    //public int fechaBaja {get;set;}
    //public int fechaAlta {get;set;}
    //public bool Activo {get;set;}
}