using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduXAPI.DTO
{
    public class Register
    {
        [Required(ErrorMessage = "Informe o Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }
    }
}
