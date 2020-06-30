using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CliMed.Data;
using CliMed.Models;
using System.Runtime.InteropServices.ComTypes;

namespace CliMed.Controllers
{
    public class ExistenciasController : Controller
    {
        private readonly CliMedBD db;


        public ExistenciasController(CliMedBD context)
        {
            this.db = context;
        }


        // GET: Existencias
        public async Task<IActionResult> Index()
        {
            var exitenciasBD = db.Existencias.Include(c => c.Clinica).Include(p => p.Produto);

            return View(await exitenciasBD.ToListAsync());
        }

        // GET: Existencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var existencias = await db.Existencias
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
            ViewData["ClinicaFK"] = new SelectList(db.Clinicas, "IdClinica", "Nome");
            ViewData["ProdutoFK"] = new SelectList(db.Produtos, "IDProduto", "Designacao"); 

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
                db.Add(existencias);
                await db.SaveChangesAsync();
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

            var existencias = await db.Existencias.FindAsync(id);
            if (existencias == null)
            {
                return NotFound();
            }
            ViewData["ClinicaFK"] = new SelectList(db.Clinicas, "IdClinica", "Nome", existencias.ClinicaFK);
            ViewData["ProdutoFK"] = new SelectList(db.Produtos, "IDProduto", "Designacao", existencias.ProdutoFK);
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
                    db.Update(existencias);
                    await db.SaveChangesAsync();
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
            ViewData["ClinicaFK"] = new SelectList(db.Clinicas, "IdClinica", "Nome",existencias.ClinicaFK);
            ViewData["ProdutoFK"] = new SelectList(db.Produtos, "IDProduto", "Designacao", existencias.ProdutoFK);

            return View(existencias);
        }

        // GET: Existencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var existencias = await db.Existencias
                 .Include(c => c.Clinica)
                 .Include(p => p.Produto)
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
            var existencias = await db.Existencias.FindAsync(id);
            db.Existencias.Remove(existencias);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExistenciasExists(int id)
        {
            return db.Existencias.Any(e => e.IdExistencia == id);
        }
    }
}
