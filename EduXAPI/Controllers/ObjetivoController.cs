using EduXAPI.Domains;
using EduXAPI.Interfaces;
using EduXAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduXAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivoController : ControllerBase
    {
        private readonly iObjetivo _objetivoRepository;

        public ObjetivoController()
        {
            _objetivoRepository = new ObjetivoRepository();
        }

        /// <summary>
        /// Lista os objetivos
        /// </summary>
        /// <returns>Objetivos</returns>
        [HttpGet]
        public List<Objetivos> Get()
        {
            try
            {
                return _objetivoRepository.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca objetivo pelo Id
        /// </summary>
        /// <param name="id">Id do objetivo que está sendo buscado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Objetivos Get(Guid id)
        {
            try
            {
                return _objetivoRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um novo objetivo
        /// </summary>
        /// <param name="objetivo">Objetivo que será adicionado</param>
        [HttpPost]
        public void Post(Objetivos objetivo)
        {
            try
            {
                _objetivoRepository.Adicionar(objetivo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Edita um objetivo existente
        /// </summary>
        /// <param name="id">Id do novo objetivo alterado</param>
        /// <param name="objetivo">Objetivo que será alterado</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Objetivos objetivo)
        {
            try
            {
                objetivo.IdObjetivo = id;
                _objetivoRepository.Editar(objetivo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um objetivo existente
        /// </summary>
        /// <param name="id">Id do objetivo que será excluído</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                _objetivoRepository.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
