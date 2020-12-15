using EduXAPI.Contexts;
using EduXAPI.Domains;
using EduXAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduXAPI.Repositories
{
    public class DicaRepository : iDica
    {
        private readonly EduXAPIContext _ctx;

        public DicaRepository()
        {
            _ctx = new EduXAPIContext();
        }
        public void Adicionar(Dicas dica)
        {
            try
            {
                _ctx.Dicas.Add(dica);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Dicas BuscarPorId(Guid id)
        {
            try
            {

                Dicas dica = _ctx.Dicas.Find(id);

                return dica;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Dicas dica)
        {
            try
            {
                Dicas dicaTemp = BuscarPorId(dica.IdDica);

                if (dicaTemp == null)
                    throw new Exception("Dica não encontrada");

                dicaTemp.Texto = dica.Texto;
                dicaTemp.Imagem = dica.Imagem;


                _ctx.Dicas.Update(dicaTemp);
                _ctx.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Dicas> Listar()
        {
            try
            {
                return _ctx.Dicas.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                Dicas dicaTemp = BuscarPorId(id);

                if (dicaTemp == null)
                    throw new Exception("Dica não encontrada");

                _ctx.Dicas.Remove(dicaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
