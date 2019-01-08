using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Goals.API.Core;
using Goals.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Goals.API.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("{v:apiVersion}/[controller]")]
    [Authorize]
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

        // GET 1.0/goals
        [HttpGet]        
        [ProducesResponseType(typeof(IEnumerable<Goal>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            _logger.Log(LogLevel.Information, "Called Get");

            var goals = await _repository.GetGoalsAsync();

            return Ok(goals);
        }

        // GET 1.0/goals/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Goal), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            _logger.Log(LogLevel.Information, "Called Get with Id");

            var goal = await _repository.GetGoalAsync(id);

            if (goal == null)
            {
                _logger.Log(LogLevel.Error, $"Error getting goal with Id {id}");

                throw new KeyNotFoundException();
            }

            return Ok(goal);
        }

        // POST 1.0/goals
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
                _logger.Log(LogLevel.Error, $"Error posting goal, see Stack trace:  {ex.StackTrace}");
                throw ex;
            }
            return NoContent();
        }

        // PUT 1.0/goals/5
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
                _logger.Log(LogLevel.Error, $"Error putting Goal, see Stack Trace {ex.StackTrace}");

                throw ex;
            }
            return NoContent();
        }

        // DELETE 1.0/goals/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                var goal = await _repository.GetGoalAsync(id);

                if (goal == null)
                {
                    _logger.Log(LogLevel.Error, $"Error finding goals with id: {id}");
                    throw new KeyNotFoundException();
                }

                await _repository.DeleteGoalAsync(goal);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Error deleting goal with id: {id}, see stack trace {ex.StackTrace}");
            }
        }
    }
}
