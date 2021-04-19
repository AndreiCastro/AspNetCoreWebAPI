using Microsoft.AspNetCore.Mvc;
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
        //GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
