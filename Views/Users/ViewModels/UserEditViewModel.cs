using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proyecto.Views.Users.ViewModels;

public class UserEditViewModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public required SelectList Roles { get; set; }
}