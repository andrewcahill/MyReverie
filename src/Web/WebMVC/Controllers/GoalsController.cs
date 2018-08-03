using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC.Interfaces;
using WebMVC.ViewModels;
using WebMVC.ViewModels.GoalViewModels;

namespace WebMVC.Controllers
{
    public class GoalsController : Controller
    {
        private readonly IGoalService _goalService;
        private readonly ILogger _logger;

        public GoalsController(IGoalService goalService, ILogger<GoalsController> logger)
        {
            _goalService = goalService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new IndexViewModel()
            {
                Goals = await _goalService.GetGoals()
            };

            // Will log something more meaningful then this - this is just test for now
            _logger.Log(LogLevel.Information, "Called Index method");

            return View(vm);
        }

        public async Task<IActionResult> Details(int goalId)
        {
            var vm = new DetailsViewModel()
            {
                Goal = await _goalService.GetGoal(goalId)
            };

            // Will log something more meaningful then this - this is just test for now
            _logger.Log(LogLevel.Information, "Called Details method");

            return View(vm);
        }

        public async Task<IActionResult> Edit(int goalId)
        {
            var vm = new EditViewModel()
            {
                Goal = await _goalService.GetGoal(goalId)
            };

            // Will log something more meaningful then this - this is just test for now
            _logger.Log(LogLevel.Information, "Called Edit method");

            return View(vm);
        }

        // POST: test/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Goal goal)
        {
            try
            {
                await _goalService.PutGoalAsync(goal);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Goal goal)
        {
            try
            {
                await _goalService.AddGoalAsync(goal);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public async Task<IActionResult> Delete(int goalId)
        {
            var vm = new DeleteViewModel()
            {
                Goal = await _goalService.GetGoal(goalId)
            };

            // Will log something more meaningful then this - this is just test for now
            _logger.Log(LogLevel.Information, "Called Delete method");

            return View(vm);
        }

        // POST: Default/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Goal goal)
        {
            try
            {
                await _goalService.DeleteGoalAsync(goal);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}