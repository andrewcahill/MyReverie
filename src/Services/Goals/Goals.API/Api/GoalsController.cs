using Goals.API.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Goals.API.Api
{
    [Route("api/[controller]")]
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

        // GET: api/<GoalsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.Log(LogLevel.Information, "Called Get");

            var goals = await _repository.GetGoalsAsync();

            return Ok(goals);
        }
    }
}
