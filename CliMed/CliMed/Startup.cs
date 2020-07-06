using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CliMed.Data;
using Microsoft.AspNetCore.Mvc;

namespace CliMed
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            //****************************************************************************
            // especificação do 'tipo' e 'localização' da BD
            services.AddDbContext<CliMedBD>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("ConnectionDB")));
            //****************************************************************************



            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CliMedBD>();

            /*Nota: .AddRoles<IdentityRole>()  -> Quando o Utilizador faz login é necessário que os Roles que lhe
             estão atribuidos seja Lidos e Respectivamente Atribuídos*/

            services.AddControllersWithViews();
            services.AddRazorPages();


            //Serviço de Autenticação via google

            services.AddAuthentication().AddGoogle(options =>
             {
                IConfigurationSection googleAuthNSection =
                    Configuration.GetSection("Authentication:Google");

                 options.ClientId = "271566846950-lokht9aokmqmro0s4recgqel3mptpqft.apps.googleusercontent.com";
                 options.ClientSecret = "zKF8OSgejsZinWS7ddWpIc6z";
             });



            /*Configuração para o EmailSender*/

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
