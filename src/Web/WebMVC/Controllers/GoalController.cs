using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC.Services;
using WebMVC.ViewModels.GoalViewModels;

namespace WebMVC.Controllers
{
    public class GoalController : Controller
    {
        private readonly IGoalService _goalService;
        private readonly ILogger _logger;

        public GoalController(IGoalService goalService, ILogger<GoalController> logger)
        {
            _goalService = goalService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new IndexViewModel()
            {
                Goal = await _goalService.GetGoal()
            };

            // Will log something more meaningful then this - this is just test for now
            _logger.Log(LogLevel.Information, "Called Index method");

            return View(vm);
        }
    }
}