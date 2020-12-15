using System;
using System.Collections.Generic;

namespace EduXAPI.Domains
{
    public partial class ProfessorTurmas
    {
        public Guid IdProfessorTurma { get; set; }
        public string Descricao { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdTurma { get; set; }

        public virtual Turmas IdTurmaNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
