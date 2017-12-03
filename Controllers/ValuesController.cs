using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {
                soru="Sorunun texti",
                cevaplar= new string[] { "şık1", "şık2", "şık3" }}
                );
                
        }

        // GET api/values/5
       /* [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
*/
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]dynamic value)
        {
            int answer=value.Answer;
            return Ok(new {your_answer=answer,true_answer=3});
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
