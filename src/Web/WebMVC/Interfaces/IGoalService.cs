using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.ViewModels;

namespace WebMVC.Interfaces
{
    public interface IGoalService
    {
        Task<Goal> GetGoal(int id);

        Task<List<Goal>> GetGoals();

        Task PutGoalAsync(Goal goal);

        Task AddGoalAsync(Goal goal);

        Task DeleteGoalAsync(Goal goal);
    }
}
