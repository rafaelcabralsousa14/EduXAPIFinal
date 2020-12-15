using System;
using System.Collections.Generic;

namespace EduXAPI.Domains
{
    public partial class Instituicoes
    {
        public Instituicoes()
        {
            Cursos = new HashSet<Cursos>();
        }

        public Guid IdInstituicao { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }

        public virtual ICollection<Cursos> Cursos { get; set; }
    }
}
