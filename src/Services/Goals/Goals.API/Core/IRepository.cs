using System.Collections.Generic;
using System.Threading.Tasks;
using Goals.API.Core.Entities;

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
