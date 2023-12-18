using System.ComponentModel.DataAnnotations;

namespace Proyecto.ViewModels;

public class PuestosVM{

    public int Id {get; set;}
    public string Nombre {get;set;}
    public int? SectorId {get;set;}
}