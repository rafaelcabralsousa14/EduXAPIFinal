using System;
using System.Collections.Generic;

namespace EduXAPI.Domains
{
    public partial class Dicas
    {
        public Dicas()
        {
            Curtidas = new HashSet<Curtidas>();
        }

        public Guid IdDica { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        public Guid? IdUsuario { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Curtidas> Curtidas { get; set; }
    }
}
