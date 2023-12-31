using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;
using Proyecto.ViewModels;
using Proyecto.Services;
using SQLitePCL;
using Microsoft.AspNetCore.Authorization;

namespace Proyecto.Controllers
{
    [Authorize]
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoService _empleadoService;


        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // GET: Empleados
        public async Task<IActionResult> Index(string filter)
        {
            var EmpleadosListVM = new EmpleadoListVM();
            var empleadoList = await _empleadoService.GetAll(filter);
            foreach (var item in empleadoList)
            {
                EmpleadosListVM.Empleados.Add(new EmpleadosVM{
                    Id=item.Id,
                    Nombre=item.Nombre,
                    Apellido=item.Apellido,
                    Edad=item.Edad,
                    Sueldo=item.Sueldo,
                    Ambiguedad=item.Ambiguedad,
                    FechaAlta=item.FechaAlta,
                    FechaBaja=item.FechaBaja,
                    Activo=item.Activo
                });
            }
            return View (EmpleadosListVM);
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var empleado= await _empleadoService.GetById(id);
            if (empleado == null)
            {
                return NotFound();
            }
            var empleadoVM = new EmpleadosVM {
                    Id=empleado.Id,
                    Nombre=empleado.Nombre,
                    Apellido=empleado.Apellido,
                    Edad=empleado.Edad,
                    Sueldo=empleado.Sueldo,
                    Ambiguedad=empleado.Ambiguedad,
                    FechaAlta=empleado.FechaAlta,
                    FechaBaja=empleado.FechaBaja,
                    Activo=empleado.Activo
            };
          

            return View(empleadoVM);
        }

        // GET: Empleados/Create
        public async Task<IActionResult> Create()
        {
            var empleadoList= await _empleadoService.GetAllEmpleados();
            if (empleadoList== null) empleadoList=new List<Empleado>();
            ViewData["Empleados"]=new SelectList(empleadoList, "Id", "nombre");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Edad,Sueldo,Ambiguedad")] EmpleadosVM empleado)
        {
            if (ModelState.IsValid)
            {
               var empleadoList= await _empleadoService.GetAllEmpleados();
               
               var newEmpleado= new Empleado{
                Nombre=empleado.Nombre,
                Apellido=empleado.Apellido,
                Edad=empleado.Edad,
                Sueldo=empleado.Sueldo,
                Ambiguedad=empleado.Ambiguedad
               };
                 
                await _empleadoService.Create(newEmpleado);
                return RedirectToAction(nameof(Index));
            }
                return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var empleados = await _empleadoService.GetById(id);
            if (id == null || empleados == null)
            {
                return NotFound();
            }

            var empleadoVM= new EmpleadosVM{
                Nombre=empleados.Nombre,
                Apellido=empleados.Apellido,
                Edad=empleados.Edad,
                Sueldo=empleados.Sueldo,
                Ambiguedad=empleados.Ambiguedad,
            };

            return View(empleadoVM);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nombre,Apellido,Edad,Sueldo,Ambiguedad")] EmpleadosVM  empleado)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    var updateEmpleado = new Empleado {
                    Id=empleado.Id,
                    Nombre=empleado.Nombre,
                    Apellido=empleado.Apellido,
                    Edad=empleado.Edad,
                    Sueldo=empleado.Sueldo,
                    Ambiguedad=empleado.Ambiguedad,
                    FechaAlta=empleado.FechaAlta,
                    FechaBaja=empleado.FechaBaja,
                    Activo=empleado.Activo
                    };
                    await _empleadoService.Update(updateEmpleado);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Unsubscribe(int? id)
        {
           var empleado=await _empleadoService.GetById(id);
           if(empleado==null)
           {
             return NotFound();
           }
            var empleadoVM = new EmpleadosVM {
             Id=empleado.Id,
             Nombre=empleado.Nombre,
             Apellido=empleado.Apellido,
             Edad=empleado.Edad,
             Sueldo=empleado.Sueldo,
             Ambiguedad=empleado.Ambiguedad,
             FechaAlta=empleado.FechaAlta,
             FechaBaja=empleado.FechaBaja,
             Activo=empleado.Activo
             };

            return View(empleadoVM);
        }
           public async Task<IActionResult> Delete(int? id)
        {
           var empleado=await _empleadoService.GetById(id);
           if(empleado==null)
           {
             return NotFound();
           }
            var empleadoVM = new EmpleadosVM {
             Id=empleado.Id,
             Nombre=empleado.Nombre,
             Apellido=empleado.Apellido,
             Edad=empleado.Edad,
             Sueldo=empleado.Sueldo,
             Ambiguedad=empleado.Ambiguedad,
             FechaAlta=empleado.FechaAlta,
             FechaBaja=empleado.FechaBaja,
             Activo=empleado.Activo
             };

            return View(empleadoVM);
        }


        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Unsubscribe")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnsubscribeConfirmed(int id)
        {
            if (id !=0)
            {
              await _empleadoService.Unsubscribe(id);
            }
            return RedirectToAction(nameof(Index));
        }
         [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id !=0)
            {
              await _empleadoService.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
