using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Views.Users.ViewModels;
using Proyecto.Models;
using Microsoft.AspNetCore.Authorization;
namespace Proyecto.Controllers;

[Authorize]
public class UsersController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UsersController(
        ILogger<HomeController> logger,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        //listar todos los usuarios
        var users = _userManager.Users.ToList();
        return View(users);
    }
     public async Task<IActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);


        var userViewModel = new UserEditViewModel
        {
            UserName = user.UserName ?? string.Empty,
            Email = user.Email ?? string.Empty,
            Roles = new SelectList(_roleManager.Roles.ToList())
        };

        return View(userViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserEditViewModel model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);
       if (user != null)
       {
           await _userManager.AddToRoleAsync(user, model.Role);
       }

        return RedirectToAction("Index");
    }
      // Acción para mostrar detalles de un usuario específico
    public async Task<ActionResult> Details(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        return View(user);
    }


    // Acción para eliminar un usuario
    public async Task<ActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        return View(user);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<ActionResult> DeleteConfirmedAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound(); // O alguna acción si el usuario no se encuentra
        }

        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            // Si el usuario se eliminó correctamente, redirige a la lista de usuarios u otra página
            return RedirectToAction("Index");
        }
        else
        {
            // Si hay errores al eliminar el usuario, maneja el escenario correspondiente
            return View("Error"); 
        }
    }


}
