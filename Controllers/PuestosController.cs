using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;
using Proyecto.Services;
using Proyecto.ViewModels;

namespace Proyecto.Controllers
{
    [Authorize(Roles="Administrador, Encargado")]
    public class PuestosController : Controller
    {
        private readonly IPuestoService _puestoService;

        public PuestosController(IPuestoService puestoService)
        {
            _puestoService = puestoService;
        }

        // GET: Puestos
        public async Task<IActionResult> Index(string filter)
        {
            var puestoListVM = new PuestosListVM();
            var puestoList = await _puestoService.GetAll(filter);
            // Mapeamos la entidad con el view model para enviar a la vista
            foreach (var item in puestoList)
            {
                puestoListVM.Puestos.Add(new PuestosVM {
                    Id = item.Id,
                    Nombre= item.Nombre,
                    SectorId=item.SectorId
                });
            }

            return View (puestoListVM);
        }

        // GET: Puestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var puesto = await _puestoService.GetById(id);
            if (puesto == null)
            {
                return NotFound();
            }
            var puestoVM= new PuestosVM{
                Id = puesto.Id,
                Nombre= puesto. Nombre,
            };
            return View(puestoVM);
        }

        // GET: Puestos/Create
        public async Task<IActionResult> Create()
        {
           var puestoList= await _puestoService.GetAllPuestos();
            if (puestoList== null) puestoList=new List<Puesto>();
            ViewData["Puesto"]=new SelectList(puestoList, "Nombre", "SectorId");
            return View();
        }

        // POST: Puestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,SectorId")] PuestosVM newPuesto)
        {
          
            if (ModelState.IsValid)
            {
                var puestoList = await _puestoService.GetAllPuestos();
                var puesto= new Puesto{
                    Nombre= newPuesto.Nombre,
                    SectorId=newPuesto.SectorId,
                };
                await _puestoService.Create(puesto);
                return RedirectToAction(nameof(Index));
            }
            return View(newPuesto);
        }

        // GET: Puestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var puesto = await _puestoService.GetById(id);
            if (puesto == null)
            {
                return NotFound();
            }

            var puestoVM= new PuestosVM{
                Id = puesto.Id,
                Nombre= puesto. Nombre,
            };
            return View(puestoVM);
        }

        // POST: Puestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,SectorId")] PuestosVM puesto)
        {
         
            if (ModelState.IsValid)
            {
                try
                {
                    var puestoVM= new Puesto{
                     Id = puesto.Id,
                     Nombre= puesto. Nombre,
                    };
                    await _puestoService.Update(puestoVM);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                   throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(puesto);
        }

        // GET: Puestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var puesto = await _puestoService.GetById(id);
            if (puesto == null)
            {
                return NotFound();
            }
            var puestoVM= new PuestosVM{
                Id = puesto.Id,
                Nombre= puesto. Nombre,
            };

            return View(puestoVM);
        }

        // POST: Puestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(id !=0)
            {
                 await _puestoService.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
        

        

    }
}
