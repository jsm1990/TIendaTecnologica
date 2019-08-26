using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaTecnologica.Models
{
    public class Contacto
    {
        public int ConId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        public string Mensaje { get; set; }
    }
}
