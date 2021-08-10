using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Data;
using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;
        private readonly string professorNullo = "Professor não encontrado";

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        //GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        //GET: api/id
        [HttpGet("ById/{id:int}")]
        public IActionResult Get(int id)
        {
            var professor = _context.Professores.FirstOrDefault(x => x.Id == id);
            if (professor == null) return BadRequest(professorNullo);

            return Ok(professor);
        }

        //GET: api/nome
        [HttpGet("ByName/{nome}")]
        public IActionResult Get(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(x => x.Nome == nome.Trim());
            if (professor == null) return BadRequest(professorNullo);

            return Ok(professor);
        }

        //POST api/objeto
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        //PUT api/objeto, id
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Professor professor)
        {
            //AsNoTracking serve para liberar a sessão após consulta, para atualização
            var teacher = _context.Professores.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (teacher == null) return BadRequest(professorNullo);

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        //PATH api/obejto, id
        [HttpPatch("{id:int}")]
        public IActionResult Path(int id, Professor professor)
        {
            var teacher = _context.Professores.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (teacher == null) return BadRequest(professorNullo);

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        //DELETE api/id
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(x => x.Id == id);
            if (professor == null) return BadRequest(professorNullo);

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }
    }
}
