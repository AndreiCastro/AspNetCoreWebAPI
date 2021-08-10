using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Data;
using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;
        private readonly string alunoNullo = "Aluno não encontrado";

        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        //GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        //GET: api/id
        [HttpGet("ById/{id:int}")]
        public IActionResult Get(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(x => x.Id == id);
            if (aluno == null) return BadRequest(alunoNullo);

            return Ok(aluno);
        }

        //GET: api/Nome
        [HttpGet("ByName/{nome}")]
        public IActionResult Get(string nome)
        {
            var aluno = _context.Alunos.FirstOrDefault(x => x.Nome == nome);
            if (aluno == null) return BadRequest(alunoNullo);
            return Ok(aluno);
        }

        //POST: api/objeto
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        //PUT: api/objeto
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            //O AsNoTracking da consulta serve para não trava a consulta, pois se ficar travada, não executa o proxímo comando 
            var studie = _context.Alunos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (studie == null) return BadRequest(alunoNullo);

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        //PATCH: api/objeto
        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var studie = _context.Alunos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (studie == null) return BadRequest(alunoNullo);

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        //DELETE: api/id
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var studie = _context.Alunos.FirstOrDefault(x => x.Id == id);
            if (studie == null) return BadRequest(alunoNullo);

            _context.Remove(studie);
            _context.SaveChanges();
            return Ok();
        }      
    }
}
