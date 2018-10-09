using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Goals.API.Core;
using Goals.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Goals.API.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger _logger;

        public GoalsController(ILogger logger, IRepository repository)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET api/1.0/goals
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Goal>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var goals = await _repository.GetGoalsAsync();

            _logger.Log(LogLevel.Information, "Called Get");

            return Ok(goals);
        }

        // GET api/1.0/goals/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Goal), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var goal = await _repository.GetGoalAsync(id);

            if (goal == null)
            {
                throw new KeyNotFoundException();
            }

            _logger.Log(LogLevel.Information, "Called Get with Id");

            return Ok(goal);
        }

        // POST api/1.0/goals
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Goal goal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // would like to handle notfound in contexgt

            try
            {
                await _repository.AddGoalAsync(goal);
            }
            catch (Exception ex)
            {

            }
            return NoContent();
        }

        // PUT api/1.0/goals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Goal goal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != goal.Id)
            {
                return BadRequest();
            }

            // would like to handle notfound in contexgt

            try
            {
                await _repository.UpdateGoalAsync(goal);
            }
            catch (Exception ex)
            {

            }
            return NoContent();
        }

        // DELETE api/1.0/goals/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                var goal = await _repository.GetGoalAsync(id);

                if (goal == null)
                {
                    throw new KeyNotFoundException();
                }

                await _repository.DeleteGoalAsync(goal);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
