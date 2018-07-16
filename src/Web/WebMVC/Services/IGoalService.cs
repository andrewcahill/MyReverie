using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.ViewModels;

namespace WebMVC.Services
{
    public interface IGoalService
    {
        Task<Goal> GetGoal();
    }
}
