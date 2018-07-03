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
                    .GetAsync($"api/goals/5");

                Assert.Equal("value", await response.Content.ReadAsStringAsync());
            }
        }
    }
}
