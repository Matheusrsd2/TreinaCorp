using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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


        [HttpPost("upload")]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, filename.Replace("\"", " ").Trim());

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest("Erro ao tentar realizar upload");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}
