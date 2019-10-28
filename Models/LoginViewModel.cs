using System.ComponentModel.DataAnnotations;

namespace TiendaTecnologica.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Display(Name = "Recordarme")]
        public bool Recordarme { get; set; }
    }
}