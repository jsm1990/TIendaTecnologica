using System;
using System.Collections.Generic;

namespace TiendaTecnologica.Models
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public string VenId { get; set; }
        public string VenFecha { get; set; }
        public decimal VenSubtotal { get; set; }
        public decimal VenImpuesto { get; set; }
        public decimal VenTotal { get; set; }
        public string VenCliente { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
