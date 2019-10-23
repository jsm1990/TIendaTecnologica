using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaTecnologica.Models
{
    public class ListaDeCompras
    {
        public float Subtotal { get; set; }
        public float Impuesto { get; set; }
        public float Total { get; set; }
        public IList<Direcciones> ListaDeDirecciones{ get; set; }
        public IList<MediosDePago> ListaDeMediosPago { get; set; }
        public IList<Item> ListaDeProductos { get; set; }
    }

}
