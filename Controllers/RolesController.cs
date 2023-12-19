using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Proyecto.Views.Roles.ViewModels;
using Proyecto.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Proyecto.Controllers;
 [Authorize]
public class RolesController : Controller
{
   
    private readonly ILogger<HomeController> _logger;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RolesController(
        ILogger<HomeController> logger,
        RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        //listar todos los roles
        var roles = _roleManager.Roles.ToList();
        return View(roles);
    }

    public IActionResult Create()
    {
        var rolesList= new List<Roles>(); 
        if (rolesList== null) rolesList=new List<Roles>();
        ViewData["Roles"]=new SelectList(rolesList, "Id", "RoleName");
        return View();
        
    }

    [HttpPost]
    public IActionResult Create(RoleCreateViewModel model)
    {
        if(string.IsNullOrEmpty(model.RoleName))
        {
            return View();
        }

        var role = new IdentityRole(model.RoleName);
        _roleManager.CreateAsync(role);

        return RedirectToAction("Index");
    }
      public ActionResult Details(string roleName)
    {
        
        return View();
    }
     public ActionResult Edit(string roleName)
    {
        return View();
    }

    [HttpPost]
    public ActionResult Edit(string roleName, string newRoleName)
    {
        try
        {
            // Lógica para actualizar el nombre de un rol
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
     public ActionResult Delete(string roleName)
    {
        // Lógica para obtener y mostrar la confirmación de eliminación de un rol por su nombre
        return View();
    }

    [HttpPost]
    [ActionName("Delete")]
    public ActionResult DeleteConfirmed(string roleName)
    {
        try
        {
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
    

}
