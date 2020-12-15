using System;
using System.Collections.Generic;

namespace EduXAPI.Domains
{
    public partial class AlunoTurmas
    {
        public AlunoTurmas()
        {
            ObjetivoAlunos = new HashSet<ObjetivoAlunos>();
        }

        public Guid IdAlunoTurma { get; set; }
        public string Matricula { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdTurma { get; set; }

        public virtual Turmas IdTurmaNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<ObjetivoAlunos> ObjetivoAlunos { get; set; }
    }
}
