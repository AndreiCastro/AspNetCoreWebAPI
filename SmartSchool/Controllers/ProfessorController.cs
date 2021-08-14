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
        private readonly string professorNullo = "Professor não encontrado";
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        //GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            var rtn = _repo.GetAllProfessores(true);
            return Ok(rtn);
        }

        //GET: api/id
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest(professorNullo);

            return Ok(professor);
        }

        //POST api/objeto
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if(_repo.SaveChanges()) return Ok(professor);

            return BadRequest(professorNullo);
        }

        //PUT api/objeto, id
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Professor professor)
        {
            var teacher = _repo.GetProfessorById(id);
            if (teacher == null) return BadRequest(professorNullo);

            _repo.Update(professor);
            if(_repo.SaveChanges()) return Ok(professor);

            return BadRequest(professorNullo);
        }

        //PATH api/obejto, id
        [HttpPatch("{id:int}")]
        public IActionResult Path(int id, Professor professor)
        {
            var teacher = _repo.GetProfessorById(id);
            if (teacher == null) return BadRequest(professorNullo);

            _repo.Update(professor);
            if(_repo.SaveChanges()) return Ok(professor);

            return BadRequest(professorNullo);
        }

        //DELETE api/id
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest(professorNullo);

            _repo.Delete(professor);
            if(_repo.SaveChanges()) return Ok();

            return BadRequest(professorNullo);
        }
    }
}
