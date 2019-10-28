using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaTecnologica.Models;

namespace TiendaTecnologica.Controllers
{
    public class PagoController : Controller
    {
        TiendaContext db = new TiendaContext();
        // GET: Pago
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pago/Details/5
        public ActionResult IrALPago(ListaDeCompras listaDeCompras)
        {
            var IdUsuario = ObtenerIdUsuario();
            listaDeCompras.Direccion = ObtenerLaDireccionDelCliente(IdUsuario);

            return View("Pago", listaDeCompras);
        }

        private Direcciones ObtenerLaDireccionDelCliente(int idCliente)
        {
            var laDireccion = new Direcciones();
            if (idCliente != 0)
            {
                laDireccion = db.Direcciones.Where(p => p.IdUsuario.Equals(idCliente)).FirstOrDefault();
            }

            if (laDireccion == null)
            {
                laDireccion = new Direcciones();
                laDireccion.IdDireccion = 1;
                laDireccion.IdUsuario = 1;
                laDireccion.Provincia = "Alajuela";
                laDireccion.Direccion = "300 metros norte";
                laDireccion.Canton = "Zarcero";
                laDireccion.Distrito = "Laguna";
            }

            return laDireccion;
        }

        private int ObtenerIdUsuario()
        {
            var elIdUsuario = 1;
            return elIdUsuario;
        }

    }
}