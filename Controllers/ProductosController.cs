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
        public const float ValorImpuesto = 0.13F; 
        TiendaContext db = new TiendaContext();

        public IActionResult Index()
        {
            var productos = db.Productos; 
            return View(productos.ToList());
        }
        public IActionResult Detalle(string IdProducto)
        {
            var productos = ListarProducto(IdProducto);
            return View(productos);
        }
        public IActionResult CarritoDeCompras(Dictionary<string, string> productos)
        {
            var listaDeCompras = new ListaDeCompras();
            listaDeCompras.ListaDeProductos = ObtenerProductosSeleccionados(productos);
            listaDeCompras.ListaDeDirecciones = ObtenerDireccionesUsuario(productos);
            listaDeCompras.ListaDeMediosPago = ObtenerMediosPagosUsuario(productos);
            listaDeCompras.Subtotal = ObtenerSubtotal(listaDeCompras.ListaDeProductos);
            listaDeCompras.Impuesto = listaDeCompras.Subtotal * ValorImpuesto;
            listaDeCompras.Total = listaDeCompras.Subtotal + listaDeCompras.Impuesto;

            return View("CarritoDeCompras",listaDeCompras);
        }

        private float ObtenerSubtotal(IList<Productos> productos)
        {
            float Subtotal = 0;
            foreach (Productos item in productos)
            {
                Subtotal += (item.ProPrecio * item.ProCantidad);
            }
            return Subtotal;
        }

        private IList<Direcciones> ObtenerDireccionesUsuario(Dictionary<string, string> productos)
        {
            IList<Direcciones> ListaDirecciones = null;

            foreach (KeyValuePair<string, string> item in productos)
            {
            }
            return ListaDirecciones;
        }

        private IList<MediosDePago> ObtenerMediosPagosUsuario(Dictionary<string, string> productos)
        {
            IList<MediosDePago> ListaMediosDePago = null;

            foreach (KeyValuePair<string, string> item in productos)
            {
            }
            return ListaMediosDePago;
        }

        private IList<Productos> ObtenerProductosSeleccionados(Dictionary<string, string> productos)
        {
            List<Productos> ListaProductos = new List<Productos>();

            foreach(KeyValuePair<string, string> item in productos)
            {
                Productos elProducto = db.Productos.Where(p => p.ProId.Equals(item.Key)).FirstOrDefault();
                if (elProducto != null)
                {
                    elProducto.ProCantidad = Convert.ToInt16(item.Value);
                    ListaProductos.Add(elProducto);
                }
            }
            return ListaProductos;
        }
        public Productos ListarProducto(string IdProducto)
        {
            var producto = db.Productos.Where(p => p.ProId.Equals(IdProducto)).FirstOrDefault();
            return producto;
        }
        public IActionResult Buscar(string textoBusqueda)
        {
            var productos = db.Productos.ToList();
            if (!String.IsNullOrEmpty(textoBusqueda))
                productos = productos.Where(p => p.ProDescricion.ToUpper().Contains(textoBusqueda.ToUpper())).ToList();
               
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
