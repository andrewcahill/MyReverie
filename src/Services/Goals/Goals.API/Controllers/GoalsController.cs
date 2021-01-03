using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Goals.API.ApiModels;
using Goals.API.Core;
using Goals.API.Exceptions;
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
        [ProducesResponseType(typeof(IEnumerable<GoalDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            _logger.Log(LogLevel.Information, "Called Get");

            var goals = await _repository.GetGoalsAsync();

            return Ok(goals);
        }

        // GET 1.0/goals/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GoalDTO), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            _logger.Log(LogLevel.Information, "Called Get with Id");

            try
            {
                var goal = await _repository.GetGoalAsync(id);

                //if (goal == null)
                //{
                    //_logger.Log(LogLevel.Error, $"Error getting goal with Id {id}");

                    //throw new KeyNotFoundException();
                //}

                return Ok(goal);

            }
            catch (GoalNotFoundException)
            {
                _logger.Log(LogLevel.Error, $"Error getting goal with Id {id}");

                throw new GoalNotFoundException($"Cannot find goal: {id}");
            }
        }

        // POST 1.0/goals
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GoalDTO goal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // would like to handle notfound in contexgt

            // Convert from DTO to internal model, now Entity
            // Will probably use Automapper

            Goals.API.Core.Entities.Goal goalEntity = new Core.Entities.Goal()
            {
                Id = goal.Id,
                Name = goal.Name,
                Description = goal.Description,
                TargetDate = goal.TargetDate
            };

            try
            {
                await _repository.AddGoalAsync(goalEntity);
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
        public async Task<IActionResult> Put(int id, [FromBody] GoalDTO goal)
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

            Goals.API.Core.Entities.Goal goalEntity = new Core.Entities.Goal()
            {
                Id = goal.Id,
                Name = goal.Name,
                Description = goal.Description,
                TargetDate = goal.TargetDate
            };

            try
            {
                await _repository.UpdateGoalAsync(goalEntity);
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
