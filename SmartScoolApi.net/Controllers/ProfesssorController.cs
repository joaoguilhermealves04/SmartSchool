using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScoolApi.net.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProfessorControllers : ControllerBase
    {
        public ProfessorControllers() { }

        [HttpGet]
        public IActionResult GetResult()
        {
            return Ok("Professores:Miguel,Felipe,Gabriel,Julia");
        }
    }
}
