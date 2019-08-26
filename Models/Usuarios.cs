using System;
using System.Collections.Generic;

namespace TiendaTecnologica.Models
{
    public partial class Usuarios
    {
        public int UsuId { get; set; }
        public string UsuNombre { get; set; }
        public string UsuCorreo { get; set; }
        public string UsuUsuario { get; set; }
        public string UsuContraseña { get; set; }
    }
}
