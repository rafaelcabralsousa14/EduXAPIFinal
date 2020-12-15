using System;
using System.Collections.Generic;

namespace EduXAPI.Domains
{
    public partial class Curtidas
    {
        public Guid IdCurtida { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdDica { get; set; }

        public virtual Dicas IdDicaNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
