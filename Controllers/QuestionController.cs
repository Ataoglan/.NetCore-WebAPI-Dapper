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
            if(!question.Any()){ //hiç elemanı var mı onu kontrol ediyor
                return BadRequest();
            }
            return Ok(question);
        }

        [HttpPost]
        public IActionResult Post([FromBody]dynamic value)
        {
            int answer=value.Answer;
            int id=value.id; //sorunun ID'si
            int true_answer = _rep.getAnswer(id);
            return Ok(new {your_answer=answer,dogru_cevap=true_answer,id=id});
        }

    }
}
