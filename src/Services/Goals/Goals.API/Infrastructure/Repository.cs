using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Goals.API.Core;
using Goals.API.Core.Entities;
using Goals.API.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Goals.API.Infrastructure
{
    public class Repository : IRepository
    {
        private GoalContext _goalContext;

        public Repository(GoalContext goalContext)
        {
            _goalContext = goalContext ?? throw new ArgumentNullException(nameof(goalContext));
        }

        public async Task<IEnumerable<Goal>> GetGoalsAsync()
        {
            return await _goalContext.Goals.ToListAsync();
        }

        public async Task<Goal> GetGoalAsync(int id)
        {
            var goal = await _goalContext.Goals.FindAsync(id);

            if (goal == null)
            {   
                throw new GoalNotFoundException($"Cannot find goal: {id}");
            }
            return goal;// await _goalContext.Goals.FindAsync(id);
        }

        public async Task AddGoalAsync(Goal goal)
        {
            await _goalContext.AddAsync(goal);
            await _goalContext.SaveChangesAsync();
        }

        public async Task UpdateGoalAsync(Goal goal)
        {
            _goalContext.Update(goal);
            await _goalContext.SaveChangesAsync();
        }

        public async Task DeleteGoalAsync(Goal goal)
        {
            _goalContext.Remove(goal);
            await _goalContext.SaveChangesAsync();
        }
    }
}
