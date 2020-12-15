using System;
using System.Collections.Generic;

namespace EduXAPI.Domains
{
    public partial class Perfis
    {
        public Perfis()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public Guid IdPerfil { get; set; }
        public string Permissao { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
