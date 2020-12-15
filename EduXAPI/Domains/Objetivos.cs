using System;
using System.Collections.Generic;

namespace EduXAPI.Domains
{
    public partial class Objetivos
    {
        public Objetivos()
        {
            ObjetivoAlunos = new HashSet<ObjetivoAlunos>();
        }

        public Guid IdObjetivo { get; set; }
        public string Descricao { get; set; }
        public Guid? IdCategoria { get; set; }

        public virtual Categorias IdCategoriaNavigation { get; set; }
        public virtual ICollection<ObjetivoAlunos> ObjetivoAlunos { get; set; }
    }
}
