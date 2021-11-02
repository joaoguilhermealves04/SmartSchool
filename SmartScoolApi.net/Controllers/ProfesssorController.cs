using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartScoolApi.net.Data;
using SmartScoolApi.net.Dtos;
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
        private readonly IMapper _mapper;
        public ProfessorControllers(IRepository repo,Mapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetResult()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(result));
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetResult(int id)
        {
            var professor = _repo.GetProfessorById(id);
              
            if (professor == null) return BadRequest("Professor não Encontrado");

            var professorDto = _mapper.Map<ProfessorDto>(professor);

            return Ok(professorDto);
        }

        
        [HttpPost]
        public IActionResult Post(ProfessorDto model)
        {
            var professor=_mapper.Map<ProfessorDto>(model);
            _repo.Add(professor);
            if (_repo.SaveChanger())
            {
                return Created($"api/professor/{model.Id}",_mapper.Map<ProfessorDto>(professor));
            }


            return BadRequest("Professor Não Cadastrado");
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int id,ProfessorDto model)
        {
            var professor = _repo.GetProfessorById(id,false);
            if (professor == null) return BadRequest("Professor Não Encontrado");

            _mapper.Map(professor,model);
            _repo.Updata(professor);

            if (_repo.SaveChanger())
            {
                return Created($"api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Não Atualizado");
        }

        [HttpPatch ("{Id}")]
        public IActionResult Patch (int id,ProfessorDto model)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor Não Encontrado");

            _mapper.Map(professor, model);
            _repo.Updata(professor);

            if (_repo.SaveChanger())
            {
                return Created($"api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
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
