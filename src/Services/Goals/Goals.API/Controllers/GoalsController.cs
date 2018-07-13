using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Goals.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        // GET api/1.0/goals
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/1.0/goals/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/1.0/goals
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/1.0/goals/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/1.0/goals/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
