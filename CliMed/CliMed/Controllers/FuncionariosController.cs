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
    public class FuncionariosController : Controller
    {
        private readonly CliMedBD db;

        public FuncionariosController(CliMedBD context)
        {
            db = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            var cliMedBD = db.Funcionarios.Include(f => f.Clinica);
            return View(await cliMedBD.ToListAsync());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await db.Funcionarios
                .Include(f => f.Clinica)
                .FirstOrDefaultAsync(f => f.IdFuncionario == id);
            if (funcionarios == null)
            {
                //return NotFound();
                RedirectToAction("Index");
            }

            return View(funcionarios);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            ViewData["ClinicaFK"] = new SelectList(db.Clinicas, "IdClinica", "Contacto");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFuncionario,Nome,DataNasc,Contacto,Mail,Morada,CC,NIF,ClinicaFK")] Funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                db.Add(funcionarios);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClinicaFK"] = new SelectList(db.Clinicas, "IdClinica", "Contacto", funcionarios.ClinicaFK);
            return View(funcionarios);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await db.Funcionarios.FindAsync(id);
            if (funcionarios == null)
            {
                //return NotFound();
                RedirectToAction("Index");
            }
            ViewData["ClinicaFK"] = new SelectList(db.Clinicas, "IdClinica", "Contacto", funcionarios.ClinicaFK);
            return View(funcionarios);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFuncionario,Nome,DataNasc,Contacto,Mail,Morada,CC,NIF,ClinicaFK")] Funcionarios funcionarios)
        {
            if (id != funcionarios.IdFuncionario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(funcionarios);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionariosExists(funcionarios.IdFuncionario))
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
            ViewData["ClinicaFK"] = new SelectList(db.Clinicas, "IdClinica", "Contacto", funcionarios.ClinicaFK);
            return View(funcionarios);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await db.Funcionarios
                .Include(f => f.Clinica)
                .FirstOrDefaultAsync(f => f.IdFuncionario == id);
            if (funcionarios == null)
            {
                //return NotFound();
                RedirectToAction("Index");
            }

            return View(funcionarios);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionarios = await db.Funcionarios.FindAsync(id);
            db.Funcionarios.Remove(funcionarios);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionariosExists(int id)
        {
            return db.Funcionarios.Any(f => f.IdFuncionario == id);
        }
    }
}
