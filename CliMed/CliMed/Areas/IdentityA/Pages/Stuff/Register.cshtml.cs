 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CliMed.Data;
using CliMed.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using static Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal.ExternalLoginModel;

namespace CliMed.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// Atributo que refer�ncia a bd utilizada neste sistema
        /// </summary>
        private readonly CliMedBD db;

        /*Construtor da Classe */
        public RegisterModel
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            CliMedBD context
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            db = context;
        }


        [BindProperty]
        public NewUser Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        /// Classe pertencente a um novo Utilizador, utilizada para recolher os seus dados
        /// </summary>
        public class NewUser 
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} e no m�ximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Palavra-Passe")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirma��o Palavra-Passe")]
            [Compare(nameof(Password), ErrorMessage = "A palavra-passe e a palavra-passe de confirma��o , n�o s�o iguais, por favor retifique.")]
            public string ConfirmPassword { get; set; }

            // **************************************************************
            // atributos extra, que ser�o associados � classe dos Utilizadores
            // **************************************************************

            public Utilizadores Utilizador { get; set; }

        }


        /*M�todo chamado quando o Formul�rio faz a entrega dos dados em HTTP-GET*/
        public async Task onGetAsync(string returnUrl = null) 
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            // ModelState -> Verifica��o dos dados do NewUser      
            if (ModelState.IsValid)
            {

                // adicionar o c�digo para processar o ficheiro com a imagem do User
                // copiar para aqui o c�digo feito no Create Veterin�rio
                bool haFicheiro = false;
                string auxNomeFotografia = "avatar.png";


                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Nome = Input.Utilizador.Nome,
                    Fotografia = auxNomeFotografia, // para a Fotografia ser� necess�rio executar uma a��o semelhante ao que fizemos no Create do Veterin�rio
                    TimeStamp = DateTime.Now,
                };

                /*Cria��o do Utilizador*/
                var result = await _userManager.CreateAsync(user, Input.Password);

                /*Se a cria��o do utilizador foi obtida com sucesso*/
                if (result.Succeeded)
                {
                    // houve sucesso na cria��o do utilizador
                    _logger.LogInformation("Utilizador criado com password.");

                    //Cria��o na BD , um registo como os dados do novo Utilizador
                    Utilizadores novoUtilizador = Input.Utilizador;
                    novoUtilizador.Email = Input.Email;
                    novoUtilizador.Fotografia = auxNomeFotografia;
                    // e n�o esquecer, ligar este 'Utilizador' a quem fez o Registo
                    novoUtilizador.UserID = user.Id;

                    
                    //Adicionar o novo Utilizador � BD(informa��o que fica carregada na mem�ria do Servidor ASP.NET
                    db.Add(novoUtilizador);

                    //Consolida��o dos dados no Servidor de BD
                    await db.SaveChangesAsync();
                    // Verifica��o da exist�ncia de uma foto para ser gravada no sistema
                    if (haFicheiro)
                    {
                        //using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                        //await fotoVet.CopyToAsync(stream);
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
            }

            // Caso alguma coisa falhe, na cria��o do utilizador , voltar a fazer o redisplay do formul�rio.
            return Page();
        }
    }
}
