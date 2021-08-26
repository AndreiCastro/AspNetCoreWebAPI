using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Data;
using SmartSchool.Dto;
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
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            var professor = _repo.GetAllProfessores(true);
            var rtn = _mapper.Map<IEnumerable<ProfessorDto>>(professor);

            return Ok(rtn);
        }

        //GET: api/<ProfessorController>
        [HttpGet("register")]
        public IActionResult GetRegister()
        {
            return Ok(new ProfessorRegistrarDto());
        }

        //GET: api/id
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest(professorNullo);
            var rtn = _mapper.Map<ProfessorDto>(professor);

            return Ok(rtn);
        }

        //POST api/objeto
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);
            if (_repo.SaveChanges()) return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));

            return BadRequest(professorNullo);
        }

        //PUT api/objeto, id
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {   
            var rtnProfessor = _repo.GetProfessorById(id);
            if (rtnProfessor == null) return BadRequest(professorNullo);

            var professor = _mapper.Map<Professor>(model);
            _repo.Update(professor);
            if (_repo.SaveChanges()) return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));

            return BadRequest(professorNullo);
        }

        //PATH api/obejto, id
        [HttpPatch("{id:int}")]
        public IActionResult Path(int id, ProfessorRegistrarDto model)
        {
            var teacher = _repo.GetProfessorById(id);
            if (teacher == null) return BadRequest(professorNullo);

            var professor = _mapper.Map<Professor>(model);
            _repo.Update(professor);
            if (_repo.SaveChanges()) return Created($"/pai/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));

            return BadRequest(professorNullo);
        }

        //DELETE api/id
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest(professorNullo);

            _repo.Delete(professor);
            if (_repo.SaveChanges()) return Ok("Professsor Deletado com sucesso");

            return BadRequest(professorNullo);
        }
    }
}
