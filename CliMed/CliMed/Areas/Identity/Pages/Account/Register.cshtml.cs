using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using CliMed.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using CliMed.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CliMed.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _caminho;



        /// <summary>
        /// Atributo que referência a bd utilizada neste sistema
        /// </summary>
        private readonly CliMedBD db;


        /*Construtor da Classe */
        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            CliMedBD context,
            IWebHostEnvironment caminho
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            db = context;
            this._caminho = caminho;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }


        /// <summary>
        /// Classe pertencente a um novo Utilizador, utilizada para recolher os seus dados
        /// </summary>
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Palavra-Passe")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmação Palavra-Passe")]
            [Compare(nameof(Password), ErrorMessage = "A palavra-passe e a palavra-passe de confirmação , não são iguais, por favor retifique.")]
            public string ConfirmPassword { get; set; }

            // **************************************************************
            // atributos extra, que serão associados à classe dos Utilizadores
            // **************************************************************

            public Utilizadores Utilizador { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }


        public async Task<IActionResult> OnPostAsync(IFormFile fotoUser)
        {
            string returnUrl = null;
            returnUrl = returnUrl ?? Url.Content("~/");


            /*Variáveis de Controlo do Ficheiro*/
            bool existeFicheiro = false;
            string caminhoCompleto = "";
            string auxNomeFoto = "";

            // ModelState -> Verificação dos dados do NewUser      
            if (ModelState.IsValid)
            {


                /*Verificação da Existência da Foto*/
                if (fotoUser != null) 
                {

                    if (fotoUser.ContentType == "image/jpeg" || fotoUser.ContentType == "image/png" || fotoUser.ContentType == "image/jpg")
                    {
                        //Gerar um Nome para o Ficheiro
                        Guid g;
                        g = Guid.NewGuid();

                        string extension = Path.GetExtension(fotoUser.FileName).ToLower();
                        string nomeFicheiro = g.ToString() + extension;

                        //Guardar o Ficheiro
                        caminhoCompleto = Path.Combine(_caminho.WebRootPath, "imagens\\utilizadores", nomeFicheiro);

                        //Flag a indicar que a foto existe
                        existeFicheiro = true;

                        auxNomeFoto = nomeFicheiro;
                    
                    }
                    else
                    {
                    
                    
                    
                    }
                }
            }


            var user = new ApplicationUser
            {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Nome = Input.Utilizador.Nome,
                    Fotografia = auxNomeFoto, 
                    TimeStamp = DateTime.Now,
            };

                /*Criação do Utilizador*/
                var result = await _userManager.CreateAsync(user, Input.Password);

                /*Se a criação do utilizador foi obtida com sucesso*/
                if (result.Succeeded)
                {
                    // Houve sucesso na criação do utilizador
                    _logger.LogInformation("Utilizador criado com password.");

                    //Criação na BD , um registo como os dados do novo Utilizador
                    Utilizadores novoUtilizador = Input.Utilizador;
                    novoUtilizador.Email = Input.Email;
                    novoUtilizador.Fotografia = auxNomeFoto;
                    // e não esquecer, ligar este 'Utilizador' a quem fez o Registo
                    novoUtilizador.UserID = user.Id;


                    //Adicionar o novo Utilizador à BD(informação que fica carregada na memória do Servidor ASP.NET)
                    db.Add(novoUtilizador);

                    //Consolidação dos dados no Servidor de BD
                    await db.SaveChangesAsync();

                     //Existe Foto para Gravar?
                     if (existeFicheiro)
                     {
                         //Criação de um FileStream , contendo o caminho completo da foto Da Clinica
                         using var stream = new FileStream(caminhoCompleto, FileMode.Create);

                         //"Commit"/Upload da foto
                        await fotoUser.CopyToAsync(stream);
                     }
               

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    //Envio do Email Asyncronamente 
                    await _emailSender.SendEmailAsync(Input.Email, "Confirme o Email",
                        $"Por-favor confirme a conta <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicando aqui</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            

            // Caso alguma coisa falhe, na criação do utilizador , voltar a fazer o redisplay do formulário.
            return Page();
        }
    }
}
