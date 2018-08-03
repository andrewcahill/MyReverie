using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goals.API.Model;

namespace Goals.API.Core
{
    public interface IRepository
    {
        Task<IEnumerable<Goal>> GetGoalsAsync();

        Task<Goal> GetGoalAsync(int id);

        Task AddGoalAsync(Goal goal);

        Task UpdateGoalAsync(Goal goal);

        Task DeleteGoalAsync(Goal goal);
    }
}
