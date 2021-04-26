using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaCorp.Domain;
using TreinaCorp.Repository.Classes;
using TreinaCorpAPI.Services;

namespace TreinaCorpAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        public UsuarioRepository _repo;        
        public UsuarioController(UsuarioRepository repo)
        {
            _repo = repo;
        }
        [HttpPost("register")]
        public IActionResult Register(Usuario model)
        {
            _repo.Register(model);
            return Created($"api/usuario/{model.Id}", model);
        }

        [HttpPost("login")]
        public ActionResult<dynamic> Login(Usuario model)
        {
            var user = _repo.Login(model);
            if (user != null)
            {
                // Gera o Token
                var token = TokenService.GenerateToken(user);

                // Oculta a senha
                user.Senha = "";

                // Retorna os dados
                return new
                {
                    user = user,
                    token = token
                };
            }
            else
            {
                return NotFound();
            }
        }

        
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            try
            {
                List<Usuario> lista = _repo.GetAll();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("inscricao")]
        public IActionResult InscreverUsuarioCurso(UsuarioCurso data)
        {
            UsuarioCurso model = new UsuarioCurso()
            {
                CursoId = data.CursoId,
                UsuarioId = data.UsuarioId
            };

            var results = _repo.InscreverUsuarioCurso(model.UsuarioId, model.CursoId);

            return Ok(results);
        }
    }
}
