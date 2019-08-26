using System;
using System.Collections.Generic;

namespace TiendaTecnologica.Models
{
    public partial class DetalleVenta
    {
        public string DetId { get; set; }
        public string ProId { get; set; }
        public string VenId { get; set; }
        public short DetCantidad { get; set; }
        public decimal DetPrecio { get; set; }
        public decimal DetSubtotal { get; set; }

        public virtual Productos Pro { get; set; }
        public virtual Venta Ven { get; set; }
    }
}
