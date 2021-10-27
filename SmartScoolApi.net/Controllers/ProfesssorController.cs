using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartScoolApi.net.Data;
using SmartScoolApi.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScoolApi.net.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProfessorControllers : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorControllers(IRepository repo)
        {

            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetResult()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetResult(int id)
        {
            var professor = _repo.GetProfessorById(id);
              
            if (professor == null) return BadRequest("Professor não Encontrado");

            return Ok(professor);
        }

        
        [HttpPost]
        public IActionResult Post(Professor professor)
        {

            _repo.Add(professor);
            if (_repo.SaveChanger())
            {
                return Ok ("Professor Cadastrado");
            }


            return BadRequest("Professor Não Cadastrado");
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int id,Professor professor)
        {
            var PutProfesso = _repo.GetProfessorById(id,false);
            if (professor == null) return BadRequest("Professor Não Encontrado");
            _repo.Updata(professor);

            if (_repo.SaveChanger())
            {
                return Ok("Professor Atualizado Com Sucesso");
            }

            return BadRequest("Não Atualizado");
        }

        [HttpPatch ("{Id}")]
        public IActionResult Patch (int id,Professor professor)
        {
            var pathcProfessor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor Não Encontrado");
            _repo.Add(professor);

            if (_repo.SaveChanger())
            {
                return Ok("Professor Atualizado Com Sucesso");
            }
            return BadRequest("Não Atualizado");
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id,Professor professor)
        {
            var deleteProfessor = _repo.GetAlunoById(id);
            if (professor == null) return BadRequest("Professor Não Encontrado");
            _repo.Delete(professor);

            if (_repo.SaveChanger())
            {
                return Ok("Deletado com Sucesso");
            }

            return BadRequest("Não Deletado");

        }
    }
}
