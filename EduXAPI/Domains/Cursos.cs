using System;
using System.Collections.Generic;

namespace EduXAPI.Domains
{
    public partial class Cursos
    {
        public Cursos()
        {
            Turmas = new HashSet<Turmas>();
        }

        public Guid IdCurso { get; set; }
        public string Titulo { get; set; }
        public Guid? IdInstituicao { get; set; }

        public virtual Instituicoes IdInstituicaoNavigation { get; set; }
        public virtual ICollection<Turmas> Turmas { get; set; }
    }
}
