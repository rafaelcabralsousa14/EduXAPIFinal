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
    public class TurmaController : ControllerBase
    {
        private readonly iTurma _turmaRepository;

        public TurmaController()
        {
            _turmaRepository = new TurmaRepository();
        }

        /// <summary>
        /// Lista as turmas adicionadas
        /// </summary>
        /// <returns>Lista de turmas</returns>
        [HttpGet]
        public List<Turmas> Get()
        {
            try
            {
                return _turmaRepository.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca turma por seu Id
        /// </summary>
        /// <param name="id">Id da turma buscado</param>
        /// <returns>Turma com o Id buscado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Turmas turma = _turmaRepository.BuscarPorId(id);


                if (turma == null)
                    return NotFound();

                return Ok(turma);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona uma nova turma
        /// </summary>
        /// <param name="turma">Turma que será adicionada</param>
        [HttpPost]
        public IActionResult Post(Turmas turma)
        {
            try
            {
                _turmaRepository.Adicionar(turma);

                return Ok(turma);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita uma turma existente
        /// </summary>
        /// <param name="id">Id nova da turma</param>
        /// <param name="turma">Turma que será editada</param>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Turmas turma)
        {
            try
            {
                var Turma = _turmaRepository.BuscarPorId(id);

                if (Turma == null)
                    return NotFound();

                turma.IdTurma = id;
                _turmaRepository.Editar(turma);

                return Ok(turma);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove uma turma existente
        /// </summary>
        /// <param name="id">Id da turma que será deletada</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _turmaRepository.Remover(id);
                return Ok(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
