using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
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
        [ProducesResponseType(typeof(IEnumerable<Goal>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            // Creating a dummy goal list for now this will ultimately come from data store
            var goals = new List<Goal>
            {
                new Goal() { Id = 0, Name = "First Goal" },
                new Goal() { Id = 1, Name = "Second Goal" },
                new Goal() { Id =2, Name = "Third Goal" }
            };

            return Ok(goals);
        }

        // GET api/1.0/goals/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Goal), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            // Creating a dummy goal object for now this will ultimately come from data store
            var goal = new Goal
            {
                Id = id,
                Name = "First Goal"
            };

            return Ok(goal);
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
