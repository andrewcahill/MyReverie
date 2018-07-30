using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebMVC.ViewModels;

namespace WebMVC.Services
{
    public class GoalService : IGoalService
    {
        private readonly HttpClient _httpClient;

        public GoalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Goal> GetGoal()
        {

            string uri = "https://localhost:44395/api/1.0/goals";

            var responseString = await _httpClient.GetStringAsync(uri);

            var goals = JsonConvert.DeserializeObject<List<Goal>>(responseString);


            return new Goal { Name = goals[0].Name };
        }
    }
}
