using System;
using System.Collections.Generic;

namespace EduXAPI.Domains
{
    public partial class Categorias
    {
        public Categorias()
        {
            Objetivos = new HashSet<Objetivos>();
        }

        public Guid IdCategoria { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Objetivos> Objetivos { get; set; }
    }
}
