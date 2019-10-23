using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaTecnologica.Models
{
    public class Item
    {
        public string ItemId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
    }
}
