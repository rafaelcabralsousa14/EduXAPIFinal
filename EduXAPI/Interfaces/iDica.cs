using EduXAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduXAPI.Interfaces
{
    interface iDica
    {
        List<Dicas> Listar();
        Dicas BuscarPorId(Guid id);
        void Adicionar(Dicas dica);
        void Remover(Guid id);
        void Editar(Dicas dica);
    }
}
