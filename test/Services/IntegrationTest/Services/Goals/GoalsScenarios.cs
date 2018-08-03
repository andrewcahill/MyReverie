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
                var response = await server.CreateClient()
                    .GetAsync($"api/1.0/goals/2");

                Assert.Equal("{\"id\":2,\"name\":\"First Goal\"}", await response.Content.ReadAsStringAsync());
            }
        }
    }
}
