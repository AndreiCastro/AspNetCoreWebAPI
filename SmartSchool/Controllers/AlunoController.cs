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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.Controllers
{
    /// <summary>
    /// Controler Aluno 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mappper;
        private readonly string alunoNullo = "Aluno não encontrado";

        public IRepository Repo { get; }
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mappper"></param>
        public AlunoController(IRepository repo, IMapper mappper)
        {
            _repo = repo;
            _mappper = mappper;
        }
          
        /// <summary>
        /// Metodo para retornar todos os alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var aluno = _repo.GetAllAlunos(true);
            var rtn = _mappper.Map<IEnumerable<AlunoDto>>(aluno); //Mapeou o Aluno p/ AlunoDto (reotrna uma lista por é um GetAll)

            return Ok(rtn);
        }

        /// <summary>
        /// Metodo para retornar todos os alunos (Será deletad)
        /// </summary>
        /// <returns></returns>
        [HttpGet("register")]
        public IActionResult GetRegister()
        {
            return Ok(new AlunoRegistrarDto());
        }

        /// <summary>
        /// Metodo para retornar Aluno por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest(alunoNullo);

            var rtn = _mappper.Map<AlunoDto>(aluno);
            return Ok(rtn);
        }

        /// <summary>
        /// Metodo para incluir aluno
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var aluno = _mappper.Map<Aluno>(model); //Transformando AlunoDto para Aluno, pois o _repo.Add so add Aluno

            _repo.Add(aluno);
            if (_repo.SaveChanges()) return Created($"/api/aluno/{model.Id}", _mappper.Map<AlunoDto>(aluno)); //ao salvar ja bate na url get/aluno/id

            return BadRequest(alunoNullo);
        }

        //PUT: api/objeto
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {            
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest(alunoNullo);

            _mappper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.SaveChanges()) return Created($"/api/aluno/{model.Id}", _mappper.Map<AlunoDto>(aluno));

            return BadRequest(alunoNullo);
        }

        //PATCH: api/objeto
        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest(alunoNullo);

            _mappper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.SaveChanges()) return Created($"/api/aluno/{model.Id}", _mappper.Map<AlunoDto>(aluno)); 

            return BadRequest(alunoNullo);
        }

        //DELETE: api/id
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest(alunoNullo);

            _repo.Delete(aluno);
            if (_repo.SaveChanges()) return Ok("Aluno del");

            return BadRequest("Studie no delete");
        }      
    }
}
