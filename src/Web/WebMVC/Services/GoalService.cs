using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
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
            HttpClient client = await GetClient();

            string uri = _appSettings.GoalsUrl + "/"  + id;

            try
            {

                var responseString = await client.GetStringAsync(uri);

                var goal = JsonConvert.DeserializeObject<Goal>(responseString);

                return goal;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
            {

            }
        }

        public async Task<List<Goal>> GetGoals()
        {
            HttpClient client = await GetClient();
            var content = await client.GetStringAsync(_appSettings.GoalsUrl);
            var goals = JsonConvert.DeserializeObject<List<Goal>>(content);

            return goals;
        }

        private async Task<HttpClient> GetClient()
        {
            TokenResponse tokenResponse = await GetToken();
            HttpClient client = _httpClientFactory.CreateClient("api");
            client.SetBearerToken(tokenResponse.AccessToken);
            return client;
        }

        private static async Task<TokenResponse> GetToken()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "http://identity",// "http://localhost:5000",//identity",
                Policy =
                {
                    RequireHttps = false
                }
            });
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api1"
            });
            return tokenResponse;
        }

        public async Task PutGoalAsync(Goal goalToUpdate)
        {
            HttpClient client = await GetClient();

            string uri = _appSettings.GoalsUrl + "/" + goalToUpdate.Id;

            var response = await client.PutAsync(uri, new StringContent(
                JsonConvert.SerializeObject(goalToUpdate),
                Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task AddGoalAsync(Goal goalToAdd)
        {
            HttpClient client = await GetClient();

            var response = await client.PostAsync(_appSettings.GoalsUrl, new StringContent(
                JsonConvert.SerializeObject(goalToAdd),
                Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteGoalAsync(Goal goalToDelete)
        {
            HttpClient client = await GetClient();

            string uri = _appSettings.GoalsUrl + "/" + goalToDelete.Id;

            var response = await client.DeleteAsync(uri);

            response.EnsureSuccessStatusCode();
        }
    }
}
