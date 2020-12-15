using System;
using System.Collections.Generic;

namespace EduXAPI.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            AlunoTurmas = new HashSet<AlunoTurmas>();
            Curtidas = new HashSet<Curtidas>();
            Dicas = new HashSet<Dicas>();
            ProfessorTurmas = new HashSet<ProfessorTurmas>();
        }

        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimoAcesso { get; set; }
        public Guid? IdPerfil { get; set; }

        public virtual Perfis IdPerfilNavigation { get; set; }
        public virtual ICollection<AlunoTurmas> AlunoTurmas { get; set; }
        public virtual ICollection<Curtidas> Curtidas { get; set; }
        public virtual ICollection<Dicas> Dicas { get; set; }
        public virtual ICollection<ProfessorTurmas> ProfessorTurmas { get; set; }
    }
}
