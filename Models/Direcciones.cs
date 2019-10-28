using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaTecnologica.Models
{
    public class Direcciones
    {
        public int IdDireccion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public int IdUsuario { get; set; }
        public string Direccion { get; set; }
    }
}
