using System;
using System.Collections.Generic;

namespace TiendaTecnologica.Models
{
    public partial class Productos
    {
        public Productos()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public string ProId { get; set; }
        public string CatId { get; set; }
        public string ProDescricion { get; set; }
        public decimal ProPrecio { get; set; }
        public short ProCantidad { get; set; }
        public string ProImagen { get; set; }

        public virtual Categorias Cat { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
