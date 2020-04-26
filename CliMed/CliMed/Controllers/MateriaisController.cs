using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CliMed.Data;
using CliMed.Models;
using Microsoft.AspNetCore.Http;

namespace CliMed.Controllers
{
    public class MateriaisController : Controller
    {
        private readonly CliMedBD db;


        public MateriaisController(CliMedBD context) 
        {
            db = context;
        }


        // GET: Materiais
        public async Task<IActionResult> Index()
        {
            var cliMedBD = db.Materiais.Include(f => f.Clinica);
            return View(await cliMedBD.ToListAsync());
        }

        // GET: Materiais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }

            var material = await db.Materiais
                .Include(f => f.Clinica)
                .FirstOrDefaultAsync(f => f.IdMaterial == id);

            if (material == null) 
            {
                RedirectToAction("Index");
            }


            return View(material);
        }

        // GET: Materiais/Create
        public IActionResult Create()
        {
            ViewData["ClinicaFk"] = new SelectList(db.Clinicas, "IdClinica", "Contacto");
            return View();
        }

        // POST: Materiais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaterial", "Descricao", "Stock", "Tipo", "PrecoCompra", "precoVenda", "ClinicaFK")]Materiais material)
        {
            if (ModelState.IsValid) 
            {
                db.Add(material);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClinicaFk"] = new SelectList(db.Clinicas, "IdClinica", "Contacto", material.ClinicaFK);
            return View(material);

        }

        // GET: Materiais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }

            var material =  await db.Materiais.FindAsync(id);
            if (material == null) 
            {
                RedirectToAction("Index");
            }

            ViewData["ClinicaFk"] = new SelectList(db.Clinicas, "IdClinica", "Contacto", material.ClinicaFK); 
            return View(material);
        }

        // POST: Materiais/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaterial", "Descricao", "Stock", "Tipo", "PrecoCompra", "precoVenda", "ClinicaFK")]Materiais material)
        {

            if (id != material.IdMaterial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(material);
                    await db.SaveChangesAsync();
                }
                catch
                {
                    if (!MaterialExists(material.IdMaterial))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewData["ClinicaFK"] = new SelectList(db.Clinicas, "IdClinica", "Contacto", material.ClinicaFK);
            return View(material);
        }

        // GET: Materiais/Delete/5
            public async Task<IActionResult> Delete(int? id)
           {
            if (id == null) 
            {
                return NotFound();
            }

            var material = await db.Materiais
              .Include(f => f.Clinica)
              .FirstOrDefaultAsync(f => f.IdMaterial == id);

            if (material == null) 
            {
                RedirectToAction("Index");
            }

            return View(material);
        }

        // POST: Materiais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
                var material = await db.Materiais.FindAsync(id);
                db.Materiais.Remove(material);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id) 
        {
            return db.Materiais.Any(f => f.IdMaterial == id);
        }

    }
}