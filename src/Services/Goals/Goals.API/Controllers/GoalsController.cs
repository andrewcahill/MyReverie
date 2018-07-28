using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Goals.API.Infrastructure;
using Goals.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Goals.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private GoalContext _goalContext;

        public GoalsController(GoalContext goalContext)
        {
            _goalContext = goalContext ?? throw new ArgumentNullException(nameof(goalContext));
        }

        // GET api/1.0/goals
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Goal>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var goals = await _goalContext.Goals.ToListAsync();

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
