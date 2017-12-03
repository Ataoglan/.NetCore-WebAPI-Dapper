using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Data;

namespace api.Controllers{
    
    [Route("api/questions")]
    public class QuestionControllers : Controller{

        
        QuestionRep _rep = new QuestionRep();

        [HttpGet()]
        public IActionResult GetQuestions(){
            return Ok(_rep.GetAllQuestions());
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestion(int id){
            var question = _rep.GetQuestion(id);
            if(question==null){
                return NotFound();
            }
            return Ok(question);
        }
    }
}
