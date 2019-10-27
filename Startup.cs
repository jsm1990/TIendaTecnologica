using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace TiendaTecnologica
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

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
   
            app.UseExceptionHandler("/Error");
          
            app.UseStatusCodePages();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // IMPORTANT: This session call MUST go before UseMvc()
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                      name: "busqueda",
                      template: "{controller=Productos}/{action=Buscar}/{textoBusqueda?}");
                routes.MapRoute(
                      name: "Categoria",
                      template: "{controller=Productos}/{action=PorCategoria}/{idCategoria?}");
                routes.MapRoute(
                      name: "Detalle",
                      template: "{controller=Productos}/{action=Detalle}/{IdProducto?}");
                routes.MapRoute(
                      name: "AgregarAlCarrito",
                      template: "{controller=Productos}/{action=AgregarAlCarrito}/{IdProducto?}/{Cantidad?}");
       
                routes.MapRoute(
                      name: "EliminarDelCarrito",
                      template: "{controller=Productos}/{action=EliminarDelCarrito}/{IdProducto?}");

                routes.MapRoute(
                      name: "Login",
                      template: "{controller=Autenticacion}/{action=Login}");
            });



        }
    }
}
