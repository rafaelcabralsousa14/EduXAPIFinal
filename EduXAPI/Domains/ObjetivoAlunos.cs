using System;
using System.Collections.Generic;

namespace EduXAPI.Domains
{
    public partial class ObjetivoAlunos
    {
        public Guid IdObjetivoAluno { get; set; }
        public decimal? Nota { get; set; }
        public DateTime DataEntrega { get; set; }
        public Guid? IdObjetivo { get; set; }
        public Guid? IdAlunoTurma { get; set; }

        public virtual AlunoTurmas IdAlunoTurmaNavigation { get; set; }
        public virtual Objetivos IdObjetivoNavigation { get; set; }
    }
}
