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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CliMed.Controllers
{
    public class ClinicasController : Controller
    {
        /// <summary>
        /// Atributo representa uma referência à nossa base de dados
        /// </summary>
        private readonly CliMedBD db;


        private readonly IWebHostEnvironment _caminho;

        public ClinicasController(CliMedBD context,IWebHostEnvironment caminho)
        {
            this.db = context;
            this._caminho = caminho;
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
                .FirstOrDefaultAsync(m => m.IdClinica == id);
            if (clinicas == null)
            {
                return NotFound();
            }

            return View(clinicas);
        }

        // GET: Clinicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clinicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClinica,Nome,Rua,nPorta,nAndar,CodPostal,Localidade,NIF,Contacto,EMail,Foto")] Clinicas clinicas,IFormFile fotoClinica)
        {
            /*Variáveis de controlo do Ficheiro*/
            bool existeFicheiro = false;
            string caminhoCompleto = "";

            /*Verificação da Existência da Foto*/
            if (fotoClinica != null)
            {
                /*Verificação do tipo(extensão) da foto*/
                if (fotoClinica.ContentType == "image/jpeg" || fotoClinica.ContentType == "image/png")
                {
                    //Gerar um Nome para o Ficheiro
                    Guid g;
                    g = Guid.NewGuid();

                    string extension = Path.GetExtension(fotoClinica.FileName).ToLower();
                    string nomeFicheiro = g.ToString() + extension;

                    //Guardar o Ficheiro
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "imagens\\clinicas", nomeFicheiro);


                    //Atribuiçao do nome do Ficheiro a Clinica
                    clinicas.Foto = nomeFicheiro;

                    //Flag a indicar que a foto existe
                    existeFicheiro = true;
                }
                else {
                
                    //Caso não a foto não seja legivel , atribuir uma foto por defeito?
                }
            
            }

            try
            {
                if (ModelState.IsValid)
                {
                    //Adiciona uma Clinica a BD , mas na memória do ASP .NET
                    db.Add(clinicas);

                    //"Commit" no Servidor de BD
                    await db.SaveChangesAsync();

                    //Existe Foto para Gravar?
                    if (existeFicheiro) 
                    {
                        //Criação de um FileStream , contendo o caminho completo da foto Da Clinica
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);

                        //"Commit"/Upload da foto
                        await fotoClinica.CopyToAsync(stream);
                    }

                    //Retorna Para a View do Index
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception)
            {

                throw;
            }

            //Quando ocorre um erro , reenviar os Dados da clinica para a view da sua criação.
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
                return NotFound();
            }
            return View(clinicas);
        }

        // POST: Clinicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClinica,Nome,Rua,nPorta,nAndar,CodPostal,Localidade,NIF,Contacto,EMail,Foto")] Clinicas clinicas,IFormFile fotoClinica)
        {
            /*Variáveis de controlo do Ficheiro*/
            bool existeFotoEditar = false;
            string caminhoCompleto = "";

            if (id != clinicas.IdClinica)
            {
                return NotFound();
            }

                /*Verificação da Existência da Foto*/
                if (fotoClinica != null)
                {
                    /*Verificação do tipo(extensão) da foto*/
                    if (fotoClinica.ContentType == "image/jpeg" || fotoClinica.ContentType == "image/png")
                    {
                        //Gerar um Nome para o Ficheiro
                        Guid g;
                        g = Guid.NewGuid();

                        string extension = Path.GetExtension(fotoClinica.FileName).ToLower();
                        string nomeFicheiro = g.ToString() + extension;

                        //Guardar o Ficheiro
                        caminhoCompleto = Path.Combine(_caminho.WebRootPath, "imagens\\clinicas", nomeFicheiro);


                        //Atribuiçao do nome do Ficheiro a Clinica
                        clinicas.Foto = nomeFicheiro;

                        //Neste caso como recebeu uma foto , então é para Atualizar a Foto, Flag de Editar
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
                    db.Update(clinicas);
                    await db.SaveChangesAsync();
                    
                    //Existe Foto para Editar?
                    if (existeFotoEditar)
                    {
                        //Criação de um FileStream , contendo o caminho completo da foto Da Clinica
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);

                        //"Commit"/Upload da foto
                        await fotoClinica.CopyToAsync(stream);
                    }
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
                .FirstOrDefaultAsync(m => m.IdClinica == id);
            if (clinicas == null)
            {
                return NotFound();
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
            return db.Clinicas.Any(e => e.IdClinica == id);
        }
    }
}
