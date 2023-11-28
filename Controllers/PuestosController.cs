using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;
using Proyecto.ViewModels;

namespace Proyecto.Controllers
{
    public class PuestosController : Controller
    {
        private readonly EmpleadosPuestosContext _context;

        public PuestosController(EmpleadosPuestosContext context)
        {
            _context = context;
        }

        // GET: Puestos
        public async Task<IActionResult> Index(string filter)
        {
              var query =from puestos in _context.Puestos select puestos; 
            if (!String.IsNullOrEmpty(filter))
            {
               query = query
               .Where(x=> x.Name.ToLower().Contains(filter.ToLower())); 
            }
              return View(await query.ToListAsync());
        }

        // GET: Puestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Puestos == null)
            {
                return NotFound();
            }

            var puestos = await _context.Puestos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestos == null)
            {
                return NotFound();
            }

            return View(puestos);
        }

        // GET: Puestos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Puestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Sector")] PuestosVM newPuesto)
        {
          
            if (ModelState.IsValid)
            {
                var puesto= new Puesto{
                    Name = newPuesto.Name,
                    
                };
                _context.Add(puesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newPuesto);
        }

        // GET: Puestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Puestos == null)
            {
                return NotFound();
            }

            var puestos = await _context.Puestos.FindAsync(id);
            if (puestos == null)
            {
                return NotFound();
            }
            return View(puestos);
        }

        // POST: Puestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Sector")] Puesto puestos)
        {
            if (id != puestos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puestos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestosExists(puestos.Id))
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
            return View(puestos);
        }

        // GET: Puestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Puestos == null)
            {
                return NotFound();
            }

            var puestos = await _context.Puestos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestos == null)
            {
                return NotFound();
            }

            return View(puestos);
        }

        // POST: Puestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Puestos == null)
            {
                return Problem("Entity set 'EmpleadosPuestosContext.Puestos'  is null.");
            }
            var puestos = await _context.Puestos.FindAsync(id);
            if (puestos != null)
            {
                _context.Puestos.Remove(puestos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestosExists(int id)
        {
          return (_context.Puestos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
       

    }
}
