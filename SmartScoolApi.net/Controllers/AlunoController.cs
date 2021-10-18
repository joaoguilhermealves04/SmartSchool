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
    [Route("api/Aluno")]
    public class AlunoControllers : ControllerBase
    {
        private readonly SmartContext _context;

        public AlunoControllers(SmartContext context)
        {
            _context = context;
        }

       

        [HttpGet]
        public IActionResult GetResult()
        {
            return Ok(_context.Alunos);

        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno Não encontrado.");

            return Ok(aluno);

        }

        [HttpGet("ByNome")]
        public IActionResult GetByNome(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("Aluno Não encontrado.");

            return Ok(aluno);

        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();

            return Ok("Aluno Cadastrado ");

        }

        [HttpPut("{Id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alunoput = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);

            if (alunoput == null) return BadRequest("Aluno nao Encontrado");
           
            _context.Update(aluno);
            _context.SaveChanges();

            return Ok(aluno);

        }

        [HttpPatch("{Id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {

            var alunopatch = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);

            if (alunopatch == null) return BadRequest("Aluno nao Encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);

        }

        [HttpDelete("{Id}")]
        public IActionResult delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest("Aluno não encontrdo");

            _context.Remove(aluno);

            _context.SaveChanges();

            return Ok(aluno);

        }

    }
}
