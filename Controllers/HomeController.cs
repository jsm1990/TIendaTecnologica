using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaTecnologica.Models;

namespace TiendaTecnologica.Controllers
{
    public class HomeController : Controller
    {
        TiendaContext db = new TiendaContext();

        public IActionResult Index()
        {
            var productos = db.Productos; 
            return View(productos.ToList());
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
        [HttpPost]
        public IActionResult EnviarMensaje(Contacto model)
        {
            if (ModelState.IsValid)
            {
                db.Contactos.Add(model);
                db.SaveChanges();
                ViewBag.Mensaje = String.Format("Su mensaje ha sido enviado exitosamente");
                return RedirectToAction("Contact");
            }
            else
            {
                return Index();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
