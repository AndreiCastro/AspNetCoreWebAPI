using Microsoft.AspNetCore.Mvc;
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
        //GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        //GET: api/id
        [HttpGet("ById/{id:int}")]
        public IActionResult Get(int id)
        {
            var fd = id;
            return Ok(fd.ToString());
        }

        //GET: api/Nome
        [HttpGet("ByName")]
        public IActionResult Get(string nome)
        {
            return Ok();
        }

        //POST: api/objeto
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        //PUT: api/objeto
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //PATCH: api/objeto
        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok();
        }

        //DELETE: api/id
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }      
    }
}
