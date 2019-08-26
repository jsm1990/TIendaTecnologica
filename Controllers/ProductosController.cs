using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaTecnologica.Models;

namespace TiendaTecnologica.Controllers
{
    public class ProductosController : Controller
    {
        TiendaContext db = new TiendaContext();

        public IActionResult Index()
        {
            var productos = db.Productos; 
            return View(productos.ToList());
        }

        public IActionResult Buscar(string textoBusqueda)
        {
            var productos = db.Productos.ToList();
            if (!String.IsNullOrEmpty(textoBusqueda))
                productos = productos.Where(p => p.ProDescricion.Contains(textoBusqueda)).ToList();
               
            return View("Productos",productos);
        }
        public IActionResult PorCategoria(string idCategoria)
        {
            var productos = db.Productos.ToList();
            if (!String.IsNullOrEmpty(idCategoria))
                productos = productos.Where(p => p.CatId.Contains(idCategoria)).ToList();

            return View("Productos", productos);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
