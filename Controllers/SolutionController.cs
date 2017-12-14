using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;

namespace api.Controllers{
    
    [Route("api/solutions")]
    public class SolutionController : Controller{
        
          QuestionRep _rep = new QuestionRep();

       [HttpGet("{id}")]
        public IActionResult GetSolution(int id){
            var solution = _rep.GetQuestion(id);
            if(!solution.Any()){ //hiç elemanı var mı onu kontrol ediyor
                return BadRequest();
            }
            return Ok(solution);
        }
    }
}