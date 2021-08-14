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
        private readonly IRepository _repo;
        private readonly string alunoNullo = "Aluno não encontrado";

        public IRepository Repo { get; }

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }
          
        //GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            var rtn = _repo.GetAllAlunos(true);
            return Ok(rtn);
        }

        //GET: api/id
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest(alunoNullo);

            return Ok(aluno);
        }

        //POST: api/objeto
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges()) return Ok(aluno);

            return BadRequest(alunoNullo);
        }

        //PUT: api/objeto
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Aluno aluno)
        {            
            var studie = _repo.GetAlunoById(id);
            if (studie == null) return BadRequest(alunoNullo);

            _repo.Update(aluno);
            if (_repo.SaveChanges()) return Ok(aluno);

            return BadRequest(alunoNullo);
        }

        //PATCH: api/objeto
        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var studie = _repo.GetAlunoById(id);
            if (studie == null) return BadRequest(alunoNullo);

            _repo.Update(aluno);
            if (_repo.SaveChanges()) return Ok(aluno);

            return BadRequest(alunoNullo);
        }

        //DELETE: api/id
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var studie = _repo.GetAlunoById(id);
            if (studie == null) return BadRequest(alunoNullo);

            _repo.Delete(studie);
            if (_repo.SaveChanges()) return Ok("Aluno del");

            return BadRequest("Studie no delete");
        }      
    }
}
