namespace Proyecto.ViewModels;

public class SectorListVM
{
    public List<SectorVM> Sector {get; set;} = new List <SectorVM>(); 
    public string? Filter {get; set;}
}