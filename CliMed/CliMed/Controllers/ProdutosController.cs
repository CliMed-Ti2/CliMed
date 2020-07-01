using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CliMed.Data;
using CliMed.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CliMed.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly CliMedBD db;

        private readonly IWebHostEnvironment _caminho;
        public ProdutosController(CliMedBD context, IWebHostEnvironment caminho)
        {
            this.db = context;
            this._caminho = caminho;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            return View(await db.Produtos.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await db.Produtos
                .FirstOrDefaultAsync(m => m.IDProduto == id);
            if (produtos == null)
            {
                return NotFound();
            }

            return View(produtos);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["ClinicaFK"] = new SelectList(db.Clinicas, "IdClinica", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDProduto,Designacao,Tipo,Foto,ClinicaFK")] Produtos produtos,IFormFile fotoProduto)
        {
            /*Variáveis de Controlo de Ficheiro*/
            bool existeFicheiro = false;
            string caminhoCompleto = "";


            /*Verificação da Existência ou não de Foto*/
            if (fotoProduto != null)
            {
                /*Verificação do tipo(extensão) da foto*/
                if (fotoProduto.ContentType == "image/jpeg" || fotoProduto.ContentType == "image/png")
                {
                    //Gerar um Nome para o Ficheiro
                    Guid g;
                    g = Guid.NewGuid();

                    string extension = Path.GetExtension(fotoProduto.FileName).ToLower();
                    string nomeFicheiro = g.ToString() + extension;

                    //Guardar o Ficheiro
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "imagens\\produtos", nomeFicheiro);


                    //Atribuiçao do nome do Ficheiro a Clinica
                    produtos.Foto = nomeFicheiro;

                    //Flag a indicar que a foto existe
                    existeFicheiro = true;
                }
                else
                {

                    //Caso não a foto não seja legivel , atribuir uma foto por defeito?
                }

            }

            if (ModelState.IsValid)
            {
                db.Add(produtos);
                await db.SaveChangesAsync();

                //Existe Foto para Gravar?
                if (existeFicheiro)
                {
                    //Criação de um FileStream , contendo o caminho completo da foto Da Clinica
                    using var stream = new FileStream(caminhoCompleto, FileMode.Create);

                    //"Commit"/Upload da foto
                    await fotoProduto.CopyToAsync(stream);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(produtos);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await db.Produtos.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }
            return View(produtos);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDProduto,Designacao,Tipo,Foto,ClinicaFK")] Produtos produtos,IFormFile fotoProduto)
        {

            /*Variável do Caminho do Ficheiro*/
            string caminhoCompleto = "";
            bool existeFotoEditar = false;


            if (id != produtos.IDProduto)
            {
                return NotFound();
            }

            /*Verificação da Existência da Foto*/
            if (fotoProduto != null)
            {
                /*Verificação do tipo(extensão) da foto*/
                if (fotoProduto.ContentType == "image/jpeg" || fotoProduto.ContentType == "image/png")
                {
                    //Gerar um Nome para o Ficheiro
                    Guid g;
                    g = Guid.NewGuid();

                    string extension = Path.GetExtension(fotoProduto.FileName).ToLower();
                    string nomeFicheiro = g.ToString() + extension;

                    //Guardar o Ficheiro
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "imagens\\produtos", nomeFicheiro);


                    //Atribuiçao do nome do Ficheiro ao Funcionáio
                    produtos.Foto = nomeFicheiro;

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
                    db.Update(produtos);
                    await db.SaveChangesAsync();
                    //Existe Foto para Editar?
                    if (existeFotoEditar)
                    {
                        //Criação de um FileStream , contendo o caminho completo da foto do Funcionário
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);

                        //"Commit"/Upload da foto
                        await fotoProduto.CopyToAsync(stream);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutosExists(produtos.IDProduto))
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
            return View(produtos);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await db.Produtos
                .FirstOrDefaultAsync(m => m.IDProduto == id);
            if (produtos == null)
            {
                return NotFound();
            }

            return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtos = await db.Produtos.FindAsync(id);
            db.Produtos.Remove(produtos);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutosExists(int id)
        {
            return db.Produtos.Any(e => e.IDProduto == id);
        }
    }
}
