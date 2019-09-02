using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaTecnologica.Models
{
    public class MediosDePago
    {
        public string IdUsuario { get; set; }
        public int IdMedioPago { get; set; }
        public string FechaVencimiento { get; set; }
        public string NombreTarjeta { get; set; }
        public string NumeroTarjeta { get; set; }

    }
}
