using EduXAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduXAPI.Interfaces
{
    public interface iObjetivo
    {
        List<Objetivos> Listar();
        Objetivos BuscarPorId(Guid id);
        void Adicionar(Objetivos objetivo);
        void Remover(Guid id);
        void Editar(Objetivos objetivo);
    }
}
