using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CliMed.Data;
using CliMed.Models;

namespace CliMed.Controllers
{
    public class ExistenciasController : Controller
    {
        private readonly CliMedBD _context;

        public ExistenciasController(CliMedBD context)
        {
            _context = context;
        }

        // GET: Existencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Existencias.ToListAsync());
        }

        // GET: Existencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var existencias = await _context.Existencias
                .FirstOrDefaultAsync(m => m.IdExistencia == id);
            if (existencias == null)
            {
                return NotFound();
            }

            return View(existencias);
        }

        // GET: Existencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Existencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExistencia,Quantidade,ClinicaFK,ProdutoFK")] Existencias existencias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(existencias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(existencias);
        }

        // GET: Existencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var existencias = await _context.Existencias.FindAsync(id);
            if (existencias == null)
            {
                return NotFound();
            }
            return View(existencias);
        }

        // POST: Existencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExistencia,Quantidade,ClinicaFK,ProdutoFK")] Existencias existencias)
        {
            if (id != existencias.IdExistencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(existencias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExistenciasExists(existencias.IdExistencia))
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
            return View(existencias);
        }

        // GET: Existencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var existencias = await _context.Existencias
                .FirstOrDefaultAsync(m => m.IdExistencia == id);
            if (existencias == null)
            {
                return NotFound();
            }

            return View(existencias);
        }

        // POST: Existencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var existencias = await _context.Existencias.FindAsync(id);
            _context.Existencias.Remove(existencias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExistenciasExists(int id)
        {
            return _context.Existencias.Any(e => e.IdExistencia == id);
        }
    }
}
