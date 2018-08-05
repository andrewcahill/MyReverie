using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebMVC.Interfaces;
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

        public async Task<Goal> GetGoal(int id)
        {
            string uri = "https://localhost:44395/api/1.0/goals/" + id;

            var responseString = await _httpClient.GetStringAsync(uri);

            var goal = JsonConvert.DeserializeObject<Goal>(responseString);

            return goal;
        }

        public async Task<List<Goal>> GetGoals()
        {
            string uri = "https://localhost:44395/api/1.0/goals";

            var responseString = await _httpClient.GetStringAsync(uri);

            var goals = JsonConvert.DeserializeObject<List<Goal>>(responseString);

            return goals;
        }

        public async Task PutGoalAsync(Goal goalToUpdate)
        {
            string uri = "https://localhost:44395/api/1.0/goals/" + goalToUpdate.Id;

            var response = await _httpClient.PutAsJsonAsync(uri, goalToUpdate);

            response.EnsureSuccessStatusCode();
        }

        public async Task AddGoalAsync(Goal goalToAdd)
        {
            string uri = "https://localhost:44395/api/1.0/goals/";

            var response = await _httpClient.PostAsJsonAsync(uri, goalToAdd);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteGoalAsync(Goal goalToDelete)
        {
            string uri = "https://localhost:44395/api/1.0/goals/" + goalToDelete.Id;

            var response = await _httpClient.DeleteAsync(uri);

            response.EnsureSuccessStatusCode();
        }
    }
}
