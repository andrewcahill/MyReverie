using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Services;
using WebMVC.ViewModels.GoalViewModels;

namespace WebMVC.Controllers
{
    public class GoalController : Controller
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new IndexViewModel()
            {
                Goal = await _goalService.GetGoal()
            };

            return View(vm);
        }
    }
}