using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaTecnologica.Models;
using Microsoft.AspNetCore.Http;

namespace TiendaTecnologica.Controllers
{
    public class ProductosController : Controller 
    {
        public const float ValorImpuesto = 0.13F; 
        TiendaContext db = new TiendaContext();

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private string sessionKey = "listaDeCompras";
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
        public IActionResult CarritoDeCompras()
        {        
            var listaDeCompras = new ListaDeCompras();
            var Items = HttpContext.Session.GetObjectFromJson<List<Item>>(sessionKey);
            listaDeCompras.ListaDeProductos = Items;
            //listaDeCompras.ListaDeDirecciones = ObtenerDireccionesUsuario(productos);
            //listaDeCompras.ListaDeMediosPago = ObtenerMediosPagosUsuario(productos);
            listaDeCompras.Subtotal = ObtenerSubtotal(Items);
            listaDeCompras.Impuesto = listaDeCompras.Subtotal * ValorImpuesto;
            listaDeCompras.Total = listaDeCompras.Subtotal + listaDeCompras.Impuesto;

            return View("CarritoDeCompras",listaDeCompras);
        }
        [HttpPost]
        public IActionResult ModificarDelCarrito(Item elItem)
        {
            var listaDeCompras = HttpContext.Session.GetObjectFromJson<List<Item>>(sessionKey);
            listaDeCompras.Replace(r => r.ItemId == elItem.ItemId, elItem);
            HttpContext.Session.SetObjectAsJson(sessionKey, listaDeCompras);

            return Redirect("/Productos/CarritoDeCompras");
        }
        public IActionResult EliminarDelCarrito(string IdProducto)
        {
            var listaDeCompras = HttpContext.Session.GetObjectFromJson<List<Item>>(sessionKey);
            var elItem = listaDeCompras.Where(i => i.ItemId == IdProducto).First();
            listaDeCompras.Remove(elItem);
            HttpContext.Session.SetObjectAsJson(sessionKey, listaDeCompras);

            string url = Request.Headers["Referer"].ToString();
            return Redirect(url);

        }
        private IList<Productos> ObtenerProductosSeleccionados(List<Item> items)
        {
            var losProductos = new List<Productos>();
            foreach(Item it in items)
            {
                var elProducto = ListarProducto(it.ItemId);
                losProductos.Add(elProducto);
            }
            return losProductos;
        }

        public IActionResult AgregarAlCarrito(string IdProducto, int Cantidad)
        {

            var listaDeCompras = HttpContext.Session.GetObjectFromJson<List<Item>>(sessionKey);
            Productos elProducto = ListarProducto(IdProducto);

            if (listaDeCompras == null)
            {
                listaDeCompras = new List<Item>();
                listaDeCompras.Add(new Item()
                {
                    ItemId = elProducto.ProId,
                    Descripcion = elProducto.ProDescricion,
                    Cantidad = 1,
                    Precio = elProducto.ProPrecio
                }); ;
                HttpContext.Session.SetObjectAsJson(sessionKey, listaDeCompras);
            }
            else
            {
                var elItem = new Item();
                elItem = listaDeCompras.Find(i => i.ItemId == IdProducto);
                if (elItem != null)
                {
                    elItem.Cantidad += 1;
                    listaDeCompras.Replace(r => r.ItemId == elItem.ItemId, elItem);
                }
                else
                {
                    listaDeCompras.Add(new Item()
                    {
                        ItemId = elProducto.ProId,
                        Descripcion = elProducto.ProDescricion,
                        Cantidad = 1,
                        Precio = elProducto.ProPrecio
                    });
                }

                HttpContext.Session.SetObjectAsJson(sessionKey, listaDeCompras);
            }
   
            string url =  Request.Headers["Referer"].ToString();
            return Redirect(url);
          
        }
        private float ObtenerSubtotal(IList<Item> productos)
        {
            float Subtotal = 0;
            foreach (Item item in productos)
            {
                Subtotal += (item.Precio * item.Cantidad);
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
