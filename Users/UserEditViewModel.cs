using Microsoft.AspNetCore.Mvc.Rendering;

namespace PARCIAL1.Views.Roles.ViewModels;

public class UserEditViewModel
{
    public string Nombre {get; set;}
    public string Email {get; set;}
    public string Rol {get; set;}

    public SelectList Roles {get; set;}
}
