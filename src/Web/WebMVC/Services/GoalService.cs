using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.ViewModels;

namespace WebMVC.Services
{
    public class GoalService : IGoalService
    {
        public async Task<Goal> GetGoal()
        {
            return new Goal { Name = "First Goal" };
        }
    }
}
