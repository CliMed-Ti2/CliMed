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
    public class ClinicasController : Controller
    {
        private readonly CliMedBD db;

        public ClinicasController(CliMedBD context)
        {
            db = context;
        }

        // GET: Clinicas
        public async Task<IActionResult> Index()
        {
            return View(await db.Clinicas.ToListAsync());
        }

        // GET: Clinicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicas = await db.Clinicas
                .FirstOrDefaultAsync(c => c.IdClinica == id);
            if (clinicas == null)
            {
                //return NotFound();
                return RedirectToAction("Index");
            }

            return View(clinicas);
        }

        // GET: Clinicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clinicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClinica,Morada,Contacto,Mail,Foto")] Clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                db.Add(clinicas);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clinicas);
        }

        // GET: Clinicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicas = await db.Clinicas.FindAsync(id);
            if (clinicas == null)
            {
                //return NotFound();
                return RedirectToAction("Index");
            }
            return View(clinicas);
        }

        // POST: Clinicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClinica,Morada,Contacto,Mail,Foto")] Clinicas clinicas)
        {
            if (id != clinicas.IdClinica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(clinicas);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicasExists(clinicas.IdClinica))
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
            return View(clinicas);
        }

        // GET: Clinicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicas = await db.Clinicas
                .FirstOrDefaultAsync(c => c.IdClinica == id);
            if (clinicas == null)
            {
                //return NotFound();
                return RedirectToAction("Index");
            }

            return View(clinicas);
        }

        // POST: Clinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clinicas = await db.Clinicas.FindAsync(id);
            db.Clinicas.Remove(clinicas);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicasExists(int id)
        {
            return db.Clinicas.Any(c => c.IdClinica == id);
        }
    }
}
