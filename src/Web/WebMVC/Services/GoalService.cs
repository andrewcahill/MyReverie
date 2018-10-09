using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebMVC.Interfaces;
using WebMVC.ViewModels;

namespace WebMVC.Services
{
    public class GoalService : IGoalService
    {
        private readonly AppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public GoalService(IOptions<AppSettings> appSettings, IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Goal> GetGoal(int id)
        {
            string uri = _appSettings.GoalsUrl + id;

            var responseString = await _httpClientFactory.CreateClient("api").GetStringAsync(uri);

            var goal = JsonConvert.DeserializeObject<Goal>(responseString);

            return goal;
        }

        public async Task<List<Goal>> GetGoals()
        {
            string uri = _appSettings.GoalsUrl;

            var responseString = await _httpClientFactory.CreateClient("api").GetStringAsync(uri);

            var goals = JsonConvert.DeserializeObject<List<Goal>>(responseString);

            return goals;
        }

        public async Task PutGoalAsync(Goal goalToUpdate)
        {
            string uri = _appSettings.GoalsUrl + goalToUpdate.Id;

            var response = await _httpClientFactory.CreateClient("api").PutAsJsonAsync(uri, goalToUpdate);

            response.EnsureSuccessStatusCode();
        }

        public async Task AddGoalAsync(Goal goalToAdd)
        {
            string uri = _appSettings.GoalsUrl;

            var response = await _httpClientFactory.CreateClient("api").PostAsJsonAsync(uri, goalToAdd);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteGoalAsync(Goal goalToDelete)
        {
            string uri = _appSettings.GoalsUrl + goalToDelete.Id;

            var response = await _httpClientFactory.CreateClient("api").DeleteAsync(uri);

            response.EnsureSuccessStatusCode();
        }
    }
}
