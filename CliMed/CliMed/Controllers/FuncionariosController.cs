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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CliMed.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly CliMedBD db;

        private readonly IWebHostEnvironment _caminho;

        public FuncionariosController(CliMedBD context, IWebHostEnvironment caminho)
        {
            this.db = context;
            this._caminho = caminho;
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
                .FirstOrDefaultAsync(m => m.IdFuncionario == id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            ViewData["ClinicaFK"] = new SelectList(db.Clinicas, "IdClinica", "Nome");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFuncionario,Nome,DataNasc,Contacto,Mail,Morada,CC,NIF,Foto,ClinicaFK")] Funcionarios funcionarios,IFormFile fotoFuncionario)
        {
            /*Variáveis de Controlo de Ficheiro*/
            bool existeFicheiro = false;
            string caminhoCompleto = "";
            
            /*Verificação da Existência ou não de Foto*/
            if (fotoFuncionario != null)
            {
                /*Verificação do tipo(extensão) da foto*/
                if (fotoFuncionario.ContentType == "image/jpeg" || fotoFuncionario.ContentType == "image/png")
                {
                    //Gerar um Nome para o Ficheiro
                    Guid g;
                    g = Guid.NewGuid();

                    string extension = Path.GetExtension(fotoFuncionario.FileName).ToLower();
                    string nomeFicheiro = g.ToString() + extension;

                    //Guardar o Ficheiro
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "imagens\\funcionarios", nomeFicheiro);


                    //Atribuiçao do nome do Ficheiro a Clinica
                    funcionarios.Foto = nomeFicheiro;

                    //Flag a indicar que a foto existe
                    existeFicheiro = true;
                }
                else
                {

                    //Caso não a foto não seja legivel , atribuir uma foto por defeito?
                }

            }

            try
            {

                if (ModelState.IsValid)
                {
                    //Adiciona uma Funcionário a BD , mas na memória do ASP .NET

                    db.Add(funcionarios);

                    //"Commit" no Servidor de BD
                    await db.SaveChangesAsync();


                    //Existe Foto para Gravar?
                    if (existeFicheiro)
                    {
                        //Criação de um FileStream , contendo o caminho completo da foto Da Clinica
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);

                        //"Commit"/Upload da foto
                        await fotoFuncionario.CopyToAsync(stream);
                    }

                    return RedirectToAction(nameof(Index));
                }
                ViewData["ClinicaFK"] = new SelectList(db.Clinicas, "IdClinica", "Nome", funcionarios.ClinicaFK);

            }
            catch (Exception)
            {

                throw;
            }

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
                return NotFound();
            }
            ViewData["ClinicaFK"] = new SelectList(db.Clinicas, "IdClinica", "Nome", funcionarios.ClinicaFK);
            return View(funcionarios);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFuncionario,Nome,DataNasc,Contacto,Mail,Morada,CC,NIF,Foto,ClinicaFK")] Funcionarios funcionarios,IFormFile fotoFuncionario)
        {

            /*Variável do Caminho do Ficheiro*/
            string caminhoCompleto = "";
            bool existeFotoEditar = false;

            if (id != funcionarios.IdFuncionario)
            {
                return NotFound();
            }

            /*Verificação da Existência da Foto*/
            if (fotoFuncionario != null)
            {
                /*Verificação do tipo(extensão) da foto*/
                if (fotoFuncionario.ContentType == "image/jpeg" || fotoFuncionario.ContentType == "image/png")
                {
                    //Gerar um Nome para o Ficheiro
                    Guid g;
                    g = Guid.NewGuid();

                    string extension = Path.GetExtension(fotoFuncionario.FileName).ToLower();
                    string nomeFicheiro = g.ToString() + extension;

                    //Guardar o Ficheiro
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "imagens\\funcionarios", nomeFicheiro);


                    //Atribuiçao do nome do Ficheiro ao Funcionáio
                    funcionarios.Foto = nomeFicheiro;

                    //Flag que indica que existe foto para ser editada
                    existeFotoEditar = true;

                }
                else
                {

                }

            }


            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(funcionarios);
                    await db.SaveChangesAsync();
                    //Existe Foto para Editar?
                    if (existeFotoEditar)
                    {
                        //Criação de um FileStream , contendo o caminho completo da foto do Funcionario
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);

                        //"Commit"/Upload da foto
                        await fotoFuncionario.CopyToAsync(stream);
                    }

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
            ViewData["ClinicaFK"] = new SelectList(db.Clinicas, "IdClinica", "Nome", funcionarios.ClinicaFK);
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
                .FirstOrDefaultAsync(m => m.IdFuncionario == id);
            if (funcionarios == null)
            {
                return NotFound();
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
            return db.Funcionarios.Any(e => e.IdFuncionario == id);
        }
    }
}
