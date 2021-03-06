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
    [Route("api/Aluno")]
    public class AlunoControllers : ControllerBase
    {
        
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoControllers(IRepository repo,IMapper mapper)
        {
          
            _repo = repo;
            _mapper = mapper;
        }

       
       

        [HttpGet]
        public IActionResult GetResult()
        {
            var alunos = _repo.GetAllALunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));

        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno Não encontrado.");

            var alunoDto = _mapper.Map<AlunoDto>(aluno);

            return Ok(alunoDto);

        }

        [HttpPost]
        public IActionResult Post(AlunoDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);
            _repo.Add(aluno);
            if (_repo.SaveChanger())
            {
                return Created($"/api/Aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno Não Cadastrado");

        }

        [HttpPut("{Id}")]
        public IActionResult Put(int id, AlunoDto model)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Alnuno Não Encontrado");

            _mapper.Map(model, aluno);
            _repo.Updata(aluno);

            if (_repo.SaveChanger())
            {
                return Created($"/api/Aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }


            return BadRequest("Aluno Não  Atualizado");

        }  

        [HttpPatch("{Id}")]
        public IActionResult Patch(int id, AlunoDto model)
        {

            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Alnuno Não Encontrado");

            _mapper.Map(model, aluno);
            _repo.Updata(aluno);

            if (_repo.SaveChanger())
            {
                return Created($"/api/Aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }


            return BadRequest("Aluno Não  Atualizado");

        }

        [HttpDelete("{Id}")]
        public IActionResult delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);


            _repo.Delete(aluno);
            if (_repo.SaveChanger())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno Não Deletado");

        }

    }
}
