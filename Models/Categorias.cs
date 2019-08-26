using System;
using System.Collections.Generic;

namespace TiendaTecnologica.Models
{
    public partial class Categorias
    {
        public Categorias()
        {
            Productos = new HashSet<Productos>();
        }

        public string CatId { get; set; }
        public string CatDescricion { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
