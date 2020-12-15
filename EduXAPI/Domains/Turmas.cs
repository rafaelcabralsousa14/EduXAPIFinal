using System;
using System.Collections.Generic;

namespace EduXAPI.Domains
{
    public partial class Turmas
    {
        public Turmas()
        {
            AlunoTurmas = new HashSet<AlunoTurmas>();
            ProfessorTurmas = new HashSet<ProfessorTurmas>();
        }

        public Guid IdTurma { get; set; }
        public string Descricao { get; set; }
        public Guid? IdCurso { get; set; }

        public virtual Cursos IdCursoNavigation { get; set; }
        public virtual ICollection<AlunoTurmas> AlunoTurmas { get; set; }
        public virtual ICollection<ProfessorTurmas> ProfessorTurmas { get; set; }
    }
}
