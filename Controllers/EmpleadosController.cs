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

namespace Proyecto.Controllers
{
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
            var EmpleadosListVM = new EmpleadosListVM();
            var empleadoList = await _empleadoService.GetAll(filter);
            foreach (var item in empleadoList)
            {
                EmpleadosListVM.Empleados.Add(new EmpleadosVM{
                    Id=item.Id,
                    Nombre=item.Nombre,
                    Apellido=item.Apellido,
                    Edad=item.Edad,
                    Sueldo=item.Sueldo,
                    Ambiguedad=item.Ambiguedad
                  
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

          

            return View(empleado);
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

            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Edad,Sueldo,Ambiguedad")] Empleado  empleado)
        
             
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _empleadoService.Update(empleado);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_empleadoService.GetById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
           var empleado=await _empleadoService.GetById(id);
           if(empleado==null)
           {
            return NotFound();
           }
             

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await _empleadoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

       

    }
}
