using Goals.API.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest.Services.Goals
{
    public class GoalsScenarios :GoalsScenarioBase
    {
        [Fact]
        public async Task Get_get_goal_by_id()
        {
            using (var server = CreateServer())
            {
                Goal goal = new Goal();
                goal.Name = "test goal";
                goal.Id = 1;

                string json = JsonConvert.SerializeObject(goal);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var request = await server.CreateClient()
                    .PostAsync($"api/1.0/goals", httpContent);

                var response = await server.CreateClient()
                    .GetAsync($"api/1.0/goals");
                var goals = (Goal[])await response.Content.ReadAsAsync(typeof(Goal[]));

                Assert.Equal(goal.Name, goals[0]?.Name);               
                Assert.True(goals[0].Id > 0);



                //var response = await server.CreateClient()
                //    .GetAsync($"api/1.0/goals/1");

                //var responseText = await response.Content.ReadAsStringAsync();
                //JObject jsonf = JObject.Parse(responseText);
                //var jsonObj = JsonConvert.DeserializeObject<Goal>(responseText);

                //Assert.Equal(goal.Name, jsonObj?.Name);
            }
        }
    }
}
