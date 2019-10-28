using System.ComponentModel.DataAnnotations;

namespace TiendaTecnologica.Models
{
    public class Usuarios
    {
        public int UsuId { get; set; }
        public string UsuNombre { get; set; }

        [Required]
        [EmailAddress]
        public string UsuCorreo { get; set; }

        [DataType(DataType.Text)]
        public string UsuUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string UsuContraseña { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "UsuContraseña")]
        [Compare("ConfirmarContraseña",
            ErrorMessage = "Las contraseñas digitadas no coinciden.")]
        public string ConfirmarContraseña { get; set; }
    }
}
