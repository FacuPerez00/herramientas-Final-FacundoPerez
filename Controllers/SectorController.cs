using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;
using Proyecto.Services;
using Proyecto.ViewModels;

namespace Proyecto.Controllers
{
    public class SectorController : Controller
    {
        private readonly ISectorService _sectorService;

        public SectorController(ISectorService sectorService)
        {
           _sectorService=sectorService;
        }
        
        // GET: Sector
        public async Task<IActionResult> Index(string filter)
        {
            var SectorListVM = new SectorListVM();
            var sectorList = await _sectorService.GetAll(filter);
            foreach (var item in sectorList)
            {
                SectorListVM.Sector.Add(new SectorVM{
                    Id=item.Id,
                    Nombre=item.Nombre,
                    Descripcion=item.Descripcion,
                });
            }
            return View (SectorListVM);
        }

        // GET: Sector/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var sector = await _sectorService.GetById(id);              
            if (sector == null)
            {
                return NotFound();
            }
            var sectorVM= new SectorVM{
                 Id=sector.Id,
                 Nombre=sector.Nombre,
                 Descripcion=sector.Descripcion,
            };

            return View(sectorVM);
        }

        // GET: Sector/Create
        public async Task<IActionResult> Create()
        {
            var sectorList= await _sectorService.GetAllEmpleados();
            if (sectorList== null) sectorList=new List<Sector>();
            ViewData["Sector"]=new SelectList(sectorList, "Id", "Nombre");
            return View();
        }

        // POST: Sector/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre, Descripcion")] SectorVM sector)
        {
            if (ModelState.IsValid)
            {
                var newSector= new Sector{
                   Nombre=sector.Nombre,
                   Descripcion=sector.Descripcion,
                };
                await _sectorService.Create(newSector);
                return RedirectToAction(nameof(Index));
            }
            return View(sector);
        }

        // GET: Sector/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            var sector = await _sectorService.GetById(id);
            if (id == null || sector== null)
            {
                return NotFound();
            }
             var sectorVM= new SectorVM{
                 Id=sector.Id,
                 Nombre=sector.Nombre,
                 Descripcion=sector.Descripcion,
            };
            return View(sectorVM);
        }

        // POST: Sector/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] SectorVM sector)
        {
          

            if (ModelState.IsValid)
            {
                try
                {
                     var updateSector= new Sector{
                     Id=sector.Id,
                     Nombre=sector.Nombre,
                     Descripcion=sector.Descripcion,
                    };

                    _sectorService.Update(updateSector);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sector);
        }
        // GET: Sector/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
               var sector= await _sectorService.GetById(id);
                if(sector==null)
                {
                 return NotFound();
                }
                 var sectorVM= new SectorVM{
                 Id=sector.Id,
                 Nombre=sector.Nombre,
                 Descripcion=sector.Descripcion,
                };
            return View(sectorVM);
        }

        // POST: Sector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(id != 0)
            {
            await _sectorService.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
