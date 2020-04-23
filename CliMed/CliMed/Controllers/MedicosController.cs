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
    public class MedicosController : Controller
    {
        private readonly CliMedBD db;

        public MedicosController(CliMedBD context)
        {
            db = context;
        }

        // GET: Medicos
        public async Task<IActionResult> Index()
        {
            return View(await db.Medicos.ToListAsync());
        }

        // GET: Medicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicos = await db.Medicos
                .FirstOrDefaultAsync(m => m.idMedico == id);
            if (medicos == null)
            {
                //return NotFound();
                return RedirectToAction("Index");
            }

            return View(medicos);
        }

        // GET: Medicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idMedico,nCedula,Nome,DataNasc,AnosExp,Contacto,Mail,Morada,CC,NIF")] Medicos medicos)
        {
            if (ModelState.IsValid)
            {
                db.Add(medicos);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicos);
        }

        // GET: Medicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicos = await db.Medicos.FindAsync(id);
            if (medicos == null)
            {
                //return NotFound();
                return RedirectToAction("Index");
            }
            return View(medicos);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idMedico,nCedula,Nome,DataNasc,AnosExp,Contacto,Mail,Morada,CC,NIF")] Medicos medicos)
        {
            if (id != medicos.idMedico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(medicos);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicosExists(medicos.idMedico))
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
            return View(medicos);
        }

        // GET: Medicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicos = await db.Medicos
                .FirstOrDefaultAsync(m => m.idMedico == id);
            if (medicos == null)
            {
                //return NotFound();
                return RedirectToAction("Index");
            }

            return View(medicos);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicos = await db.Medicos.FindAsync(id);
            db.Medicos.Remove(medicos);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicosExists(int id)
        {
            return db.Medicos.Any(m => m.idMedico == id);
        }
    }
}
