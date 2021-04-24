using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinaCorp.Domain;
using TreinaCorp.Repository.Classes;
using TreinaCorp.Repository.Interfaces;

namespace TreinaCorpAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CursoController : Controller
    {
        public readonly CursoRepository _repo;
        public CursoController(CursoRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            try
            {
                List<Curso> lista = _repo.GetAll();
                return Ok(lista);
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Curso curso = _repo.GetById(id);
            return Ok(curso);
        }
        [HttpPost] 
        public IActionResult Post( Curso curso)
        {
            try
            {
                _repo.Add(curso);
                return Created($"/api/curso/{curso.Id}", curso);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}
